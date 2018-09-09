﻿using Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabbedTortoiseGit.Properties;
using Tabs;

namespace TabbedTortoiseGit
{
    class TabControllerTag
    {
        private static readonly ILog LOG = LogManager.GetLogger( typeof( TabControllerTag ) );

        private Color _lastColor;
        private bool _modified;

        public Tab Tab { get; private set; }
        public Process Process { get; private set; }
        public String RepoItem { get; private set; }

        public bool Modified
        {
            get
            {
                return _modified;
            }

            set
            {
                if( _modified != value )
                {
                    _modified = value;
                    this.UpdateTabDisplay();
                }
            }
        }

        public static TabControllerTag CreateController( Process p, String repo )
        {
            Tab t = new Tab( repo );

            TabControllerTag tag = new TabControllerTag( t, p, repo );

            t.Tag = tag;

            tag.UpdateTabDisplay();
            tag.UpdateIcon();

            return tag;
        }

        private TabControllerTag( Tab tab, Process process, String repo )
        {
            Tab = tab;
            Process = process;
            RepoItem = repo;
            Modified = false;

            Tab.Resize += Tab_Resize;

            Process.Exited += Process_Exited;
            Process.EnableRaisingEvents = true;
        }

        public async Task WaitForStartup()
        {
            LOG.Debug( $"{nameof( WaitForStartup )} - Start Wait for MainWindowHandle - Repo: {this.RepoItem} - PID: {this.Process.Id}" );
            while( !this.Process.HasExited && this.Process.MainWindowHandle == IntPtr.Zero )
            {
                await Task.Delay( 10 );
            }
            LOG.Debug( $"{nameof( WaitForStartup )} - End Wait for MainWindowHandle - Repo: {this.RepoItem} - PID: {this.Process.Id}" );

            Native.RemoveBorder( this.Process.MainWindowHandle );
            Native.SetWindowParent( this.Process.MainWindowHandle, this.Tab );
            this.ResizeTab();
        }

        public void UpdateTabDisplay()
        {
            if( Settings.Default.IndicateModifiedTabs && this.Modified )
            {
                this.Tab.Font = Settings.Default.ModifiedTabFont;
                this.Tab.ForeColor = Settings.Default.ModifiedTabFontColor;
            }
            else
            {
                this.Tab.Font = Settings.Default.NormalTabFont;
                this.Tab.ForeColor = Settings.Default.NormalTabFontColor;
            }
        }

        public void UpdateIcon()
        {
            Color tabColor = Settings.Default.FavoriteRepos
                                                .BreadthFirst
                                                .Where( f => f.Value.Repo == this.RepoItem )
                                                .FirstOrDefault()?.Value?.Color ?? Color.Black;
            if( tabColor != _lastColor
             || this.Tab.Icon == null )
            {
                Bitmap icon;
                if( File.Exists( this.RepoItem ) )
                {
                    icon = Resources.File;
                }
                else
                {
                    icon = Resources.Folder;
                }

                if( tabColor == Color.Black )
                {
                    this.Tab.Icon = icon;
                }
                else
                {
                    this.Tab.Icon = Util.ColorBitmap( icon, tabColor );
                }

                _lastColor = tabColor;
            }
        }

        private void EndProcess()
        {
            if( !this.Process.CloseMainWindow() )
            {
                this.Process.Kill();
            }
        }

        public void Close()
        {
            this.Tab.Resize -= Tab_Resize;
            this.Tab.Parent = null;

            this.Process.EnableRaisingEvents = false;
            this.Process.Exited -= Process_Exited;

            if( !this.Process.HasExited )
            {
                Task.Run( (Action)this.EndProcess );
            }
        }

        private void ResizeTab()
        {
            Size sizeDiff = Native.ResizeToParent( this.Process.MainWindowHandle, this.Tab );

            Form form = this.Tab.FindForm();

            if( form != null )
            {
                if( sizeDiff.Width > 0 )
                {
                    form.Width += sizeDiff.Width;
                    form.MinimumSize = new Size( form.Width, form.MinimumSize.Height );
                }

                if( sizeDiff.Height > 0 )
                {
                    form.Height += sizeDiff.Height;
                    form.MinimumSize = new Size( form.MinimumSize.Width, form.Height );
                }
            }
        }

        private void Tab_Resize( object sender, EventArgs e )
        {
            if( this.Tab.FindForm()?.WindowState != FormWindowState.Minimized )
            {
                ResizeTab();
            }
        }

        private void Process_Exited( object sender, EventArgs e )
        {
            this.Tab.UiBeginInvoke( (Action)( () => this.Tab.Parent = null ) );
        }
    }

    static class TabExtensions
    {
        public static TabControllerTag Controller( this Tab tab )
        {
            return (TabControllerTag)tab.Tag;
        }
    }
}
