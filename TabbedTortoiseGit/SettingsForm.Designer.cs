﻿using System.Windows.Forms;

namespace TabbedTortoiseGit
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StartupReposList = new System.Windows.Forms.ListBox();
            this.AddDefaultRepo = new System.Windows.Forms.Button();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.RemoveDefaultRepo = new System.Windows.Forms.Button();
            this.OpenStartupReposOnReOpenCheck = new System.Windows.Forms.CheckBox();
            this.RetainLogsOnCloseCheck = new System.Windows.Forms.CheckBox();
            this.RunOnStartupCheck = new System.Windows.Forms.CheckBox();
            this.ConfirmOnCloseCheck = new System.Windows.Forms.CheckBox();
            this.MaxRecentReposNumeric = new System.Windows.Forms.NumericUpDown();
            this.MaxRecentReposLabel = new System.Windows.Forms.Label();
            this.GitActionsLabel = new System.Windows.Forms.Label();
            this.GitActionsCheckList = new System.Windows.Forms.CheckedListBox();
            this.SettingsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SettingsTabs = new System.Windows.Forms.TabControl();
            this.StartupReposTab = new System.Windows.Forms.TabPage();
            this.GitActionsTab = new System.Windows.Forms.TabPage();
            this.FastSubmoduleUpdateSettingsGroup = new System.Windows.Forms.GroupBox();
            this.CheckModifiedSubmodulesByDefaultCheck = new System.Windows.Forms.CheckBox();
            this.OtherSettingsTab = new System.Windows.Forms.TabPage();
            this.CloseToSystemTrayCheck = new System.Windows.Forms.CheckBox();
            this.DeveloperSettingsPage = new System.Windows.Forms.TabPage();
            this.ShowHitTestCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MaxRecentReposNumeric)).BeginInit();
            this.SettingsTabs.SuspendLayout();
            this.StartupReposTab.SuspendLayout();
            this.GitActionsTab.SuspendLayout();
            this.FastSubmoduleUpdateSettingsGroup.SuspendLayout();
            this.OtherSettingsTab.SuspendLayout();
            this.DeveloperSettingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartupReposList
            // 
            this.StartupReposList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartupReposList.FormattingEnabled = true;
            this.StartupReposList.IntegralHeight = false;
            this.StartupReposList.Location = new System.Drawing.Point(6, 6);
            this.StartupReposList.Name = "StartupReposList";
            this.StartupReposList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.StartupReposList.Size = new System.Drawing.Size(343, 218);
            this.StartupReposList.TabIndex = 1;
            // 
            // AddDefaultRepo
            // 
            this.AddDefaultRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddDefaultRepo.Location = new System.Drawing.Point(97, 230);
            this.AddDefaultRepo.Name = "AddDefaultRepo";
            this.AddDefaultRepo.Size = new System.Drawing.Size(85, 23);
            this.AddDefaultRepo.TabIndex = 2;
            this.AddDefaultRepo.Text = "Add Repo";
            this.AddDefaultRepo.UseVisualStyleBackColor = true;
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(216, 326);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 3;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(297, 326);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // RemoveDefaultRepo
            // 
            this.RemoveDefaultRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveDefaultRepo.Location = new System.Drawing.Point(6, 230);
            this.RemoveDefaultRepo.Name = "RemoveDefaultRepo";
            this.RemoveDefaultRepo.Size = new System.Drawing.Size(85, 23);
            this.RemoveDefaultRepo.TabIndex = 5;
            this.RemoveDefaultRepo.Text = "Remove Repo";
            this.RemoveDefaultRepo.UseVisualStyleBackColor = true;
            // 
            // OpenStartupReposOnReOpenCheck
            // 
            this.OpenStartupReposOnReOpenCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OpenStartupReposOnReOpenCheck.AutoSize = true;
            this.OpenStartupReposOnReOpenCheck.Location = new System.Drawing.Point(6, 259);
            this.OpenStartupReposOnReOpenCheck.Name = "OpenStartupReposOnReOpenCheck";
            this.OpenStartupReposOnReOpenCheck.Size = new System.Drawing.Size(277, 17);
            this.OpenStartupReposOnReOpenCheck.TabIndex = 6;
            this.OpenStartupReposOnReOpenCheck.Text = "Open Startup Repos when re-opened from Task Tray";
            this.SettingsToolTip.SetToolTip(this.OpenStartupReposOnReOpenCheck, "Only valid when \"Retain Logs on Close\" is disabled.");
            this.OpenStartupReposOnReOpenCheck.UseVisualStyleBackColor = true;
            // 
            // RetainLogsOnCloseCheck
            // 
            this.RetainLogsOnCloseCheck.AutoSize = true;
            this.RetainLogsOnCloseCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RetainLogsOnCloseCheck.Location = new System.Drawing.Point(6, 6);
            this.RetainLogsOnCloseCheck.Name = "RetainLogsOnCloseCheck";
            this.RetainLogsOnCloseCheck.Size = new System.Drawing.Size(130, 17);
            this.RetainLogsOnCloseCheck.TabIndex = 7;
            this.RetainLogsOnCloseCheck.Text = "Retain Logs on Close:";
            this.RetainLogsOnCloseCheck.UseVisualStyleBackColor = true;
            // 
            // RunOnStartupCheck
            // 
            this.RunOnStartupCheck.AutoSize = true;
            this.RunOnStartupCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RunOnStartupCheck.Location = new System.Drawing.Point(6, 101);
            this.RunOnStartupCheck.Name = "RunOnStartupCheck";
            this.RunOnStartupCheck.Size = new System.Drawing.Size(99, 17);
            this.RunOnStartupCheck.TabIndex = 11;
            this.RunOnStartupCheck.Text = "Run on startup:";
            this.RunOnStartupCheck.UseVisualStyleBackColor = true;
            // 
            // ConfirmOnCloseCheck
            // 
            this.ConfirmOnCloseCheck.AutoSize = true;
            this.ConfirmOnCloseCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ConfirmOnCloseCheck.Location = new System.Drawing.Point(6, 55);
            this.ConfirmOnCloseCheck.Name = "ConfirmOnCloseCheck";
            this.ConfirmOnCloseCheck.Size = new System.Drawing.Size(133, 17);
            this.ConfirmOnCloseCheck.TabIndex = 10;
            this.ConfirmOnCloseCheck.Text = "Prompt Before Closing:";
            this.ConfirmOnCloseCheck.UseVisualStyleBackColor = true;
            // 
            // MaxRecentReposNumeric
            // 
            this.MaxRecentReposNumeric.Location = new System.Drawing.Point(115, 29);
            this.MaxRecentReposNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxRecentReposNumeric.Name = "MaxRecentReposNumeric";
            this.MaxRecentReposNumeric.Size = new System.Drawing.Size(44, 20);
            this.MaxRecentReposNumeric.TabIndex = 9;
            this.MaxRecentReposNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MaxRecentReposLabel
            // 
            this.MaxRecentReposLabel.AutoSize = true;
            this.MaxRecentReposLabel.Location = new System.Drawing.Point(7, 31);
            this.MaxRecentReposLabel.Name = "MaxRecentReposLabel";
            this.MaxRecentReposLabel.Size = new System.Drawing.Size(102, 13);
            this.MaxRecentReposLabel.TabIndex = 8;
            this.MaxRecentReposLabel.Text = "Max Recent Repos:";
            // 
            // GitActionsLabel
            // 
            this.GitActionsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GitActionsLabel.AutoSize = true;
            this.GitActionsLabel.Location = new System.Drawing.Point(6, 206);
            this.GitActionsLabel.Name = "GitActionsLabel";
            this.GitActionsLabel.Size = new System.Drawing.Size(279, 13);
            this.GitActionsLabel.TabIndex = 1;
            this.GitActionsLabel.Text = "Note: Drag and drop items to change context menu order.";
            // 
            // GitActionsCheckList
            // 
            this.GitActionsCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GitActionsCheckList.FormattingEnabled = true;
            this.GitActionsCheckList.IntegralHeight = false;
            this.GitActionsCheckList.Location = new System.Drawing.Point(6, 6);
            this.GitActionsCheckList.Name = "GitActionsCheckList";
            this.GitActionsCheckList.Size = new System.Drawing.Size(340, 197);
            this.GitActionsCheckList.TabIndex = 0;
            this.SettingsToolTip.SetToolTip(this.GitActionsCheckList, "Only valid when \"Retain Logs on Close\" is disabled.\r\n");
            // 
            // SettingsTabs
            // 
            this.SettingsTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsTabs.Controls.Add(this.StartupReposTab);
            this.SettingsTabs.Controls.Add(this.GitActionsTab);
            this.SettingsTabs.Controls.Add(this.OtherSettingsTab);
            this.SettingsTabs.Controls.Add(this.DeveloperSettingsPage);
            this.SettingsTabs.Location = new System.Drawing.Point(12, 12);
            this.SettingsTabs.Name = "SettingsTabs";
            this.SettingsTabs.SelectedIndex = 0;
            this.SettingsTabs.Size = new System.Drawing.Size(360, 308);
            this.SettingsTabs.TabIndex = 12;
            // 
            // StartupReposTab
            // 
            this.StartupReposTab.Controls.Add(this.OpenStartupReposOnReOpenCheck);
            this.StartupReposTab.Controls.Add(this.StartupReposList);
            this.StartupReposTab.Controls.Add(this.AddDefaultRepo);
            this.StartupReposTab.Controls.Add(this.RemoveDefaultRepo);
            this.StartupReposTab.Location = new System.Drawing.Point(4, 22);
            this.StartupReposTab.Name = "StartupReposTab";
            this.StartupReposTab.Padding = new System.Windows.Forms.Padding(3);
            this.StartupReposTab.Size = new System.Drawing.Size(352, 282);
            this.StartupReposTab.TabIndex = 0;
            this.StartupReposTab.Text = "Startup Repos";
            this.StartupReposTab.UseVisualStyleBackColor = true;
            // 
            // GitActionsTab
            // 
            this.GitActionsTab.Controls.Add(this.FastSubmoduleUpdateSettingsGroup);
            this.GitActionsTab.Controls.Add(this.GitActionsLabel);
            this.GitActionsTab.Controls.Add(this.GitActionsCheckList);
            this.GitActionsTab.Location = new System.Drawing.Point(4, 22);
            this.GitActionsTab.Name = "GitActionsTab";
            this.GitActionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.GitActionsTab.Size = new System.Drawing.Size(352, 282);
            this.GitActionsTab.TabIndex = 1;
            this.GitActionsTab.Text = "Git Actions";
            this.GitActionsTab.UseVisualStyleBackColor = true;
            // 
            // FastSubmoduleUpdateSettingsGroup
            // 
            this.FastSubmoduleUpdateSettingsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FastSubmoduleUpdateSettingsGroup.Controls.Add(this.CheckModifiedSubmodulesByDefaultCheck);
            this.FastSubmoduleUpdateSettingsGroup.Location = new System.Drawing.Point(6, 234);
            this.FastSubmoduleUpdateSettingsGroup.Name = "FastSubmoduleUpdateSettingsGroup";
            this.FastSubmoduleUpdateSettingsGroup.Size = new System.Drawing.Size(340, 42);
            this.FastSubmoduleUpdateSettingsGroup.TabIndex = 3;
            this.FastSubmoduleUpdateSettingsGroup.TabStop = false;
            this.FastSubmoduleUpdateSettingsGroup.Text = "Fast Submodule Update";
            // 
            // CheckModifiedSubmodulesByDefaultCheck
            // 
            this.CheckModifiedSubmodulesByDefaultCheck.AutoSize = true;
            this.CheckModifiedSubmodulesByDefaultCheck.Location = new System.Drawing.Point(6, 19);
            this.CheckModifiedSubmodulesByDefaultCheck.Name = "CheckModifiedSubmodulesByDefaultCheck";
            this.CheckModifiedSubmodulesByDefaultCheck.Size = new System.Drawing.Size(213, 17);
            this.CheckModifiedSubmodulesByDefaultCheck.TabIndex = 2;
            this.CheckModifiedSubmodulesByDefaultCheck.Text = "Check Modified Submodules By Default";
            this.CheckModifiedSubmodulesByDefaultCheck.UseVisualStyleBackColor = true;
            // 
            // OtherSettingsTab
            // 
            this.OtherSettingsTab.Controls.Add(this.CloseToSystemTrayCheck);
            this.OtherSettingsTab.Controls.Add(this.RunOnStartupCheck);
            this.OtherSettingsTab.Controls.Add(this.RetainLogsOnCloseCheck);
            this.OtherSettingsTab.Controls.Add(this.ConfirmOnCloseCheck);
            this.OtherSettingsTab.Controls.Add(this.MaxRecentReposLabel);
            this.OtherSettingsTab.Controls.Add(this.MaxRecentReposNumeric);
            this.OtherSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.OtherSettingsTab.Name = "OtherSettingsTab";
            this.OtherSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.OtherSettingsTab.Size = new System.Drawing.Size(352, 282);
            this.OtherSettingsTab.TabIndex = 2;
            this.OtherSettingsTab.Text = "Other";
            this.OtherSettingsTab.UseVisualStyleBackColor = true;
            // 
            // CloseToSystemTrayCheck
            // 
            this.CloseToSystemTrayCheck.AutoSize = true;
            this.CloseToSystemTrayCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseToSystemTrayCheck.Location = new System.Drawing.Point(6, 78);
            this.CloseToSystemTrayCheck.Name = "CloseToSystemTrayCheck";
            this.CloseToSystemTrayCheck.Size = new System.Drawing.Size(125, 17);
            this.CloseToSystemTrayCheck.TabIndex = 12;
            this.CloseToSystemTrayCheck.Text = "Close to System Tray";
            this.CloseToSystemTrayCheck.UseVisualStyleBackColor = true;
            // 
            // DeveloperSettingsPage
            // 
            this.DeveloperSettingsPage.Controls.Add(this.ShowHitTestCheck);
            this.DeveloperSettingsPage.Location = new System.Drawing.Point(4, 22);
            this.DeveloperSettingsPage.Name = "DeveloperSettingsPage";
            this.DeveloperSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.DeveloperSettingsPage.Size = new System.Drawing.Size(352, 282);
            this.DeveloperSettingsPage.TabIndex = 3;
            this.DeveloperSettingsPage.Text = "Developer Settings";
            this.DeveloperSettingsPage.UseVisualStyleBackColor = true;
            // 
            // ShowHitTestCheck
            // 
            this.ShowHitTestCheck.AutoSize = true;
            this.ShowHitTestCheck.Location = new System.Drawing.Point(6, 6);
            this.ShowHitTestCheck.Name = "ShowHitTestCheck";
            this.ShowHitTestCheck.Size = new System.Drawing.Size(93, 17);
            this.ShowHitTestCheck.TabIndex = 0;
            this.ShowHitTestCheck.Text = "Show Hit Test";
            this.ShowHitTestCheck.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.SettingsTabs);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 225);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.MaxRecentReposNumeric)).EndInit();
            this.SettingsTabs.ResumeLayout(false);
            this.StartupReposTab.ResumeLayout(false);
            this.StartupReposTab.PerformLayout();
            this.GitActionsTab.ResumeLayout(false);
            this.GitActionsTab.PerformLayout();
            this.FastSubmoduleUpdateSettingsGroup.ResumeLayout(false);
            this.FastSubmoduleUpdateSettingsGroup.PerformLayout();
            this.OtherSettingsTab.ResumeLayout(false);
            this.OtherSettingsTab.PerformLayout();
            this.DeveloperSettingsPage.ResumeLayout(false);
            this.DeveloperSettingsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox StartupReposList;
        private System.Windows.Forms.Button AddDefaultRepo;
        private Button OK;
        private Button Cancel;
        private Button RemoveDefaultRepo;
        private CheckBox RetainLogsOnCloseCheck;
        private NumericUpDown MaxRecentReposNumeric;
        private Label MaxRecentReposLabel;
        private CheckBox ConfirmOnCloseCheck;
        private CheckedListBox GitActionsCheckList;
        private Label GitActionsLabel;
        private CheckBox RunOnStartupCheck;
        private CheckBox OpenStartupReposOnReOpenCheck;
        private ToolTip SettingsToolTip;
        private TabControl SettingsTabs;
        private TabPage StartupReposTab;
        private TabPage GitActionsTab;
        private TabPage OtherSettingsTab;
        private CheckBox CheckModifiedSubmodulesByDefaultCheck;
        private GroupBox FastSubmoduleUpdateSettingsGroup;
        private TabPage DeveloperSettingsPage;
        private CheckBox ShowHitTestCheck;
        private CheckBox CloseToSystemTrayCheck;
    }
}