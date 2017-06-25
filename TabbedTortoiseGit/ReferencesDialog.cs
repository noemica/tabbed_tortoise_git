﻿using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;

namespace TabbedTortoiseGit
{
    public partial class ReferencesDialog : Form
    {
        class DisplayReference : IFormattable
        {
            public String Reference { get; private set; }
            public String ShortReference { get; private set; }

            public DisplayReference( String reference, String shortReference )
            {
                Reference = reference;
                ShortReference = shortReference;
            }

            public override String ToString()
            {
                return ShortReference;
            }

            public string ToString( String format, IFormatProvider formatProvider )
            {
                if( format == "long" )
                {
                    return Reference;
                }
                else
                {
                    return ShortReference;
                }
            }
        }

        private readonly String _repo;

        public String[] SelectedReferences
        {
            get
            {
                return SelectedReferencesListBox.Items.Cast<DisplayReference>().Select( r => r.Reference ).ToArray();
            }
        }

        public ReferencesDialog( String repo )
        {
            InitializeComponent();

            this.Icon = Resources.TortoiseIcon;

            _repo = repo;

            this.Text = _repo + " - Select References";

            ReferencesTreeView.AfterSelect += ReferencesTreeView_AfterSelect;

            ReferencesFilterText.TextChanged += ReferencesFilterText_TextChanged;

            ReferencesListBox.MouseDoubleClick += ReferencesListBox_MouseDoubleClick;

            AddSelectedReferencesButton.Click += AddSelectedReferencesButton_Click;

            SelectedReferencesListBox.KeyUp += SelectedReferencesListBox_KeyUp;

            RemoveSelectedReferences.Click += RemoveSelectedReferences_Click;

            Ok.Click += Ok_Click;

            InitializeReferences();
        }

        private void ReferencesTreeView_AfterSelect( object sender, TreeViewEventArgs e )
        {
            UpdateDisplayedReferences();
        }

        private void ReferencesFilterText_TextChanged( object sender, EventArgs e )
        {
            UpdateDisplayedReferences();
        }

        private void ReferencesListBox_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            int index = ReferencesListBox.IndexFromPoint( e.Location );
            if( index != ListBox.NoMatches )
            {
                DisplayReference reference = (DisplayReference)ReferencesListBox.Items[ index ];
                SelectedReferencesListBox.Items.Add( reference );
            }
        }

        private void AddSelectedReferencesButton_Click( object sender, EventArgs e )
        {
            SelectedReferencesListBox.Items.AddRange( ReferencesListBox.SelectedItems.Cast<DisplayReference>().ToArray() );
            ReferencesListBox.SelectedItems.Clear();
        }

        private void SelectedReferencesListBox_KeyUp( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Delete
             || e.KeyCode == Keys.Back )
            {
                foreach( DisplayReference reference in SelectedReferencesListBox.SelectedItems.Cast<DisplayReference>().ToArray() )
                {
                    SelectedReferencesListBox.Items.Remove( reference );
                }
            }
        }

        private void RemoveSelectedReferences_Click( object sender, EventArgs e )
        {
            foreach( DisplayReference reference in SelectedReferencesListBox.SelectedItems.Cast<DisplayReference>().ToArray() )
            {
                SelectedReferencesListBox.Items.Remove( reference );
            }
        }

        private void Ok_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeReferences()
        {
            using( Repository repository = new Repository( Git.GetBaseRepoDirectory( _repo ) ) )
            {
                foreach( Reference r in repository.Refs )
                {
                    String[] splitRef = r.CanonicalName.Split( '/' );
                    AddReference( r.CanonicalName, splitRef, 0, ReferencesTreeView.Nodes );
                }
            }

            if( ReferencesTreeView.Nodes.Count > 0 )
            {
                TreeNode firstNode = ReferencesTreeView.Nodes[ 0 ];
                firstNode.Expand();
                ReferencesTreeView.SelectedNode = firstNode;
            }
        }

        private void AddReference( String reference, String[] splitRef, int index, TreeNodeCollection parentNodes )
        {
            String splitRefPart = splitRef[ index ];
            TreeNode node = parentNodes.Find( splitRefPart, false ).FirstOrDefault();
            if( node == null )
            {
                node = parentNodes.Add( splitRefPart, splitRefPart );
                node.Tag = new List<DisplayReference>();
            }

            List<DisplayReference> refs = (List<DisplayReference>)node.Tag;
            DisplayReference displayRef = new DisplayReference( reference, String.Join( "/", splitRef, index + 1, splitRef.Length - index - 1 ) );
            refs.Add( displayRef );

            if( index + 1 < splitRef.Length - 1 )
            {
                AddReference( reference, splitRef, index + 1, node.Nodes );
            }
        }

        private void UpdateDisplayedReferences()
        {
            ReferencesListBox.Items.Clear();

            if( ReferencesTreeView.SelectedNode != null )
            {
                IEnumerable<DisplayReference> references = (List<DisplayReference>)ReferencesTreeView.SelectedNode.Tag;

                String filter = ReferencesFilterText.Text.Trim().ToLower();
                if( !String.IsNullOrEmpty( filter ) )
                {
                    references = references.Where( r => r.ShortReference.ToLower().Contains( filter ) );
                }

                ReferencesListBox.Items.AddRange( references.ToArray() );
            }
        }
    }
}
