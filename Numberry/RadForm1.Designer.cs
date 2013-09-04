namespace Numberry
{
    partial class RadForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.buttonAlertAdd = new Telerik.WinControls.UI.RadButton();
            this.buttonAlertClear = new Telerik.WinControls.UI.RadButton();
            this.alertList = new Telerik.WinControls.UI.RadListView();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.buttonFilterAdd = new Telerik.WinControls.UI.RadButton();
            this.buttonFilterClear = new Telerik.WinControls.UI.RadButton();
            this.filterList = new Telerik.WinControls.UI.RadListView();
            this.pageSettings = new Telerik.WinControls.UI.RadPageViewPage();
            this.radPropertyGrid1 = new Telerik.WinControls.UI.RadPropertyGrid();
            this.buttonWrite = new Telerik.WinControls.UI.RadButton();
            this.buttonDisconnect = new Telerik.WinControls.UI.RadButton();
            this.buttonConnect = new Telerik.WinControls.UI.RadButton();
            this.tabView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAlertAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAlertClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertList)).BeginInit();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFilterAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFilterClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterList)).BeginInit();
            this.pageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPropertyGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonWrite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDisconnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabView1)).BeginInit();
            this.tabView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.Controls.Add(this.buttonAlertAdd);
            this.radPageViewPage3.Controls.Add(this.buttonAlertClear);
            this.radPageViewPage3.Controls.Add(this.alertList);
            this.radPageViewPage3.Location = new System.Drawing.Point(204, 4);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(266, 378);
            this.radPageViewPage3.Text = "Оповещение";
            // 
            // buttonAlertAdd
            // 
            this.buttonAlertAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAlertAdd.Enabled = false;
            this.buttonAlertAdd.Location = new System.Drawing.Point(0, 296);
            this.buttonAlertAdd.Name = "buttonAlertAdd";
            this.buttonAlertAdd.Size = new System.Drawing.Size(266, 41);
            this.buttonAlertAdd.TabIndex = 5;
            this.buttonAlertAdd.Text = "Добавить";
            this.buttonAlertAdd.ThemeName = "Windows8";
            this.buttonAlertAdd.Click += new System.EventHandler(this.buttonAlertAdd_Click);
            // 
            // buttonAlertClear
            // 
            this.buttonAlertClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAlertClear.Enabled = false;
            this.buttonAlertClear.Location = new System.Drawing.Point(0, 337);
            this.buttonAlertClear.Name = "buttonAlertClear";
            this.buttonAlertClear.Size = new System.Drawing.Size(266, 41);
            this.buttonAlertClear.TabIndex = 4;
            this.buttonAlertClear.Text = "Очистить";
            this.buttonAlertClear.ThemeName = "Windows8";
            this.buttonAlertClear.Click += new System.EventHandler(this.buttonAlertClear_Click);
            // 
            // alertList
            // 
            this.alertList.AllowEdit = false;
            this.alertList.Dock = System.Windows.Forms.DockStyle.Top;
            this.alertList.Location = new System.Drawing.Point(0, 0);
            this.alertList.Name = "alertList";
            this.alertList.ShowColumnHeaders = false;
            this.alertList.Size = new System.Drawing.Size(266, 297);
            this.alertList.TabIndex = 3;
            this.alertList.Text = "radListView1";
            this.alertList.ThemeName = "Windows8";
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.buttonFilterAdd);
            this.radPageViewPage2.Controls.Add(this.buttonFilterClear);
            this.radPageViewPage2.Controls.Add(this.filterList);
            this.radPageViewPage2.Location = new System.Drawing.Point(204, 4);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(266, 378);
            this.radPageViewPage2.Text = "Фильтр входящих номеров";
            // 
            // buttonFilterAdd
            // 
            this.buttonFilterAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonFilterAdd.Enabled = false;
            this.buttonFilterAdd.Location = new System.Drawing.Point(0, 296);
            this.buttonFilterAdd.Name = "buttonFilterAdd";
            this.buttonFilterAdd.Size = new System.Drawing.Size(266, 41);
            this.buttonFilterAdd.TabIndex = 2;
            this.buttonFilterAdd.Text = "Добавить";
            this.buttonFilterAdd.ThemeName = "Windows8";
            this.buttonFilterAdd.Click += new System.EventHandler(this.radButton3_Click);
            // 
            // buttonFilterClear
            // 
            this.buttonFilterClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonFilterClear.Enabled = false;
            this.buttonFilterClear.Location = new System.Drawing.Point(0, 337);
            this.buttonFilterClear.Name = "buttonFilterClear";
            this.buttonFilterClear.Size = new System.Drawing.Size(266, 41);
            this.buttonFilterClear.TabIndex = 1;
            this.buttonFilterClear.Text = "Очистить";
            this.buttonFilterClear.ThemeName = "Windows8";
            this.buttonFilterClear.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // filterList
            // 
            this.filterList.AllowEdit = false;
            this.filterList.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterList.Location = new System.Drawing.Point(0, 0);
            this.filterList.Name = "filterList";
            this.filterList.ShowColumnHeaders = false;
            this.filterList.Size = new System.Drawing.Size(266, 297);
            this.filterList.TabIndex = 0;
            this.filterList.Text = "radListView1";
            this.filterList.ThemeName = "Windows8";
            this.filterList.VisualItemCreating += new Telerik.WinControls.UI.ListViewVisualItemCreatingEventHandler(this.filterList_VisualItemCreating);
            // 
            // pageSettings
            // 
            this.pageSettings.Controls.Add(this.radPropertyGrid1);
            this.pageSettings.Controls.Add(this.buttonWrite);
            this.pageSettings.Controls.Add(this.buttonDisconnect);
            this.pageSettings.Controls.Add(this.buttonConnect);
            this.pageSettings.Location = new System.Drawing.Point(204, 4);
            this.pageSettings.Name = "pageSettings";
            this.pageSettings.Size = new System.Drawing.Size(266, 378);
            this.pageSettings.Text = "Устройство";
            // 
            // radPropertyGrid1
            // 
            this.radPropertyGrid1.AllowDefaultContextMenu = false;
            this.radPropertyGrid1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radPropertyGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radPropertyGrid1.EnableFiltering = false;
            this.radPropertyGrid1.EnableGrouping = false;
            this.radPropertyGrid1.EnableSorting = false;
            this.radPropertyGrid1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radPropertyGrid1.HelpBarHeight = 60F;
            this.radPropertyGrid1.Location = new System.Drawing.Point(0, 126);
            this.radPropertyGrid1.Name = "radPropertyGrid1";
            this.radPropertyGrid1.ReadOnly = true;
            this.radPropertyGrid1.Size = new System.Drawing.Size(266, 252);
            this.radPropertyGrid1.TabIndex = 6;
            this.radPropertyGrid1.Text = "radPropertyGrid1";
            this.radPropertyGrid1.ThemeName = "Windows8";
            // 
            // buttonWrite
            // 
            this.buttonWrite.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonWrite.Enabled = false;
            this.buttonWrite.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonWrite.Location = new System.Drawing.Point(0, 80);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(266, 40);
            this.buttonWrite.TabIndex = 3;
            this.buttonWrite.Text = "Запись";
            this.buttonWrite.ThemeName = "Windows8";
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDisconnect.Location = new System.Drawing.Point(0, 40);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(266, 40);
            this.buttonDisconnect.TabIndex = 2;
            this.buttonDisconnect.Text = "Отключиться";
            this.buttonDisconnect.ThemeName = "Windows8";
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonConnect.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnect.Location = new System.Drawing.Point(0, 0);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(266, 40);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Поиск";
            this.buttonConnect.ThemeName = "Windows8";
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // tabView1
            // 
            this.tabView1.Controls.Add(this.pageSettings);
            this.tabView1.Controls.Add(this.radPageViewPage2);
            this.tabView1.Controls.Add(this.radPageViewPage3);
            this.tabView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabView1.Location = new System.Drawing.Point(0, 0);
            this.tabView1.Name = "tabView1";
            this.tabView1.SelectedPage = this.pageSettings;
            this.tabView1.Size = new System.Drawing.Size(474, 386);
            this.tabView1.TabIndex = 4;
            this.tabView1.Text = "radPageView1";
            this.tabView1.ThemeName = "Windows8";
            this.tabView1.ViewMode = Telerik.WinControls.UI.PageViewMode.Backstage;
            // 
            // RadForm1
            // 
            this.AcceptButton = this.buttonConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 386);
            this.Controls.Add(this.tabView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NumBerry";
            this.ThemeName = "Windows8";
            this.radPageViewPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonAlertAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAlertClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertList)).EndInit();
            this.radPageViewPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonFilterAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFilterClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterList)).EndInit();
            this.pageSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPropertyGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonWrite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDisconnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabView1)).EndInit();
            this.tabView1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
        private Telerik.WinControls.UI.RadPageViewPage pageSettings;
        private Telerik.WinControls.UI.RadButton buttonWrite;
        private Telerik.WinControls.UI.RadButton buttonDisconnect;
        private Telerik.WinControls.UI.RadButton buttonConnect;
        private Telerik.WinControls.UI.RadPageView tabView1;
        private Telerik.WinControls.UI.RadButton buttonFilterAdd;
        private Telerik.WinControls.UI.RadButton buttonFilterClear;
        private Telerik.WinControls.UI.RadListView filterList;
        private Telerik.WinControls.UI.RadButton buttonAlertAdd;
        private Telerik.WinControls.UI.RadButton buttonAlertClear;
        private Telerik.WinControls.UI.RadListView alertList;
        private Telerik.WinControls.UI.RadPropertyGrid radPropertyGrid1;
    }
}
