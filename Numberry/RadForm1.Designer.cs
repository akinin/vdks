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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadForm1));
            this.windows8Theme1 = new Telerik.WinControls.Themes.Windows8Theme();
            this.radPageViewPage3 = new Telerik.WinControls.UI.RadPageViewPage();
            this.buttonAlertAdd = new Telerik.WinControls.UI.RadButton();
            this.buttonAlertClear = new Telerik.WinControls.UI.RadButton();
            this.alertList = new Telerik.WinControls.UI.RadListView();
            this.radPageViewPage2 = new Telerik.WinControls.UI.RadPageViewPage();
            this.buttonFilterAdd = new Telerik.WinControls.UI.RadButton();
            this.buttonFilterClear = new Telerik.WinControls.UI.RadButton();
            this.filterList = new Telerik.WinControls.UI.RadListView();
            this.buttonWrite = new Telerik.WinControls.UI.RadButton();
            this.buttonDisconnect = new Telerik.WinControls.UI.RadButton();
            this.buttonConnect = new Telerik.WinControls.UI.RadButton();
            this.tabView1 = new Telerik.WinControls.UI.RadPageView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radPageViewPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAlertAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonAlertClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertList)).BeginInit();
            this.radPageViewPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFilterAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFilterClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonWrite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDisconnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonConnect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabView1)).BeginInit();
            this.tabView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageViewPage3
            // 
            this.radPageViewPage3.Controls.Add(this.buttonAlertAdd);
            this.radPageViewPage3.Controls.Add(this.buttonAlertClear);
            this.radPageViewPage3.Controls.Add(this.alertList);
            this.radPageViewPage3.Location = new System.Drawing.Point(6, 87);
            this.radPageViewPage3.Name = "radPageViewPage3";
            this.radPageViewPage3.Size = new System.Drawing.Size(280, 281);
            this.radPageViewPage3.Text = "Оповещение";
            // 
            // buttonAlertAdd
            // 
            this.buttonAlertAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAlertAdd.Enabled = false;
            this.buttonAlertAdd.Location = new System.Drawing.Point(0, 199);
            this.buttonAlertAdd.Name = "buttonAlertAdd";
            this.buttonAlertAdd.Size = new System.Drawing.Size(280, 41);
            this.buttonAlertAdd.TabIndex = 5;
            this.buttonAlertAdd.Text = "Добавить";
            this.buttonAlertAdd.ThemeName = "Windows8";
            this.buttonAlertAdd.Click += new System.EventHandler(this.buttonAlertAdd_Click);
            // 
            // buttonAlertClear
            // 
            this.buttonAlertClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonAlertClear.Enabled = false;
            this.buttonAlertClear.Location = new System.Drawing.Point(0, 240);
            this.buttonAlertClear.Name = "buttonAlertClear";
            this.buttonAlertClear.Size = new System.Drawing.Size(280, 41);
            this.buttonAlertClear.TabIndex = 4;
            this.buttonAlertClear.Text = "Очистить";
            this.buttonAlertClear.ThemeName = "Windows8";
            this.buttonAlertClear.Click += new System.EventHandler(this.buttonAlertClear_Click);
            // 
            // alertList
            // 
            this.alertList.Dock = System.Windows.Forms.DockStyle.Top;
            this.alertList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.alertList.Location = new System.Drawing.Point(0, 0);
            this.alertList.Name = "alertList";
            this.alertList.ShowColumnHeaders = false;
            this.alertList.Size = new System.Drawing.Size(280, 193);
            this.alertList.TabIndex = 3;
            this.alertList.Text = "radListView1";
            this.alertList.ThemeName = "Windows8";
            this.alertList.ItemEdited += new Telerik.WinControls.UI.ListViewItemEditedEventHandler(this.List_ItemEdited);
            // 
            // radPageViewPage2
            // 
            this.radPageViewPage2.Controls.Add(this.buttonFilterAdd);
            this.radPageViewPage2.Controls.Add(this.buttonFilterClear);
            this.radPageViewPage2.Controls.Add(this.filterList);
            this.radPageViewPage2.Location = new System.Drawing.Point(6, 87);
            this.radPageViewPage2.Name = "radPageViewPage2";
            this.radPageViewPage2.Size = new System.Drawing.Size(280, 281);
            this.radPageViewPage2.Text = "Фильтр входящих номеров";
            // 
            // buttonFilterAdd
            // 
            this.buttonFilterAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonFilterAdd.Enabled = false;
            this.buttonFilterAdd.Location = new System.Drawing.Point(0, 199);
            this.buttonFilterAdd.Name = "buttonFilterAdd";
            this.buttonFilterAdd.Size = new System.Drawing.Size(280, 41);
            this.buttonFilterAdd.TabIndex = 2;
            this.buttonFilterAdd.Text = "Добавить";
            this.buttonFilterAdd.ThemeName = "Windows8";
            this.buttonFilterAdd.Click += new System.EventHandler(this.buttonFilterAdd_Click);
            // 
            // buttonFilterClear
            // 
            this.buttonFilterClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonFilterClear.Enabled = false;
            this.buttonFilterClear.Location = new System.Drawing.Point(0, 240);
            this.buttonFilterClear.Name = "buttonFilterClear";
            this.buttonFilterClear.Size = new System.Drawing.Size(280, 41);
            this.buttonFilterClear.TabIndex = 1;
            this.buttonFilterClear.Text = "Очистить";
            this.buttonFilterClear.ThemeName = "Windows8";
            this.buttonFilterClear.Click += new System.EventHandler(this.buttonFilterClear_Click);
            // 
            // filterList
            // 
            this.filterList.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filterList.Location = new System.Drawing.Point(0, 0);
            this.filterList.Name = "filterList";
            this.filterList.ShowColumnHeaders = false;
            this.filterList.Size = new System.Drawing.Size(280, 193);
            this.filterList.TabIndex = 0;
            this.filterList.Text = "radListView1";
            this.filterList.ThemeName = "Windows8";
            this.filterList.ItemEdited += new Telerik.WinControls.UI.ListViewItemEditedEventHandler(this.List_ItemEdited);
            this.filterList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.List_KeyDown);
            // 
            // buttonWrite
            // 
            this.buttonWrite.Enabled = false;
            this.buttonWrite.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonWrite.Location = new System.Drawing.Point(298, 165);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(140, 40);
            this.buttonWrite.TabIndex = 3;
            this.buttonWrite.TabStop = false;
            this.buttonWrite.Text = "Запись";
            this.buttonWrite.ThemeName = "Windows8";
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDisconnect.Location = new System.Drawing.Point(298, 328);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(140, 40);
            this.buttonDisconnect.TabIndex = 2;
            this.buttonDisconnect.TabStop = false;
            this.buttonDisconnect.Text = "Отключиться";
            this.buttonDisconnect.ThemeName = "Windows8";
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnect.Location = new System.Drawing.Point(298, 119);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(140, 40);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.TabStop = false;
            this.buttonConnect.Text = "Поиск";
            this.buttonConnect.ThemeName = "Windows8";
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // tabView1
            // 
            this.tabView1.Controls.Add(this.radPageViewPage2);
            this.tabView1.Controls.Add(this.radPageViewPage3);
            this.tabView1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabView1.Location = new System.Drawing.Point(0, 0);
            this.tabView1.Name = "tabView1";
            this.tabView1.SelectedPage = this.radPageViewPage3;
            this.tabView1.Size = new System.Drawing.Size(292, 374);
            this.tabView1.TabIndex = 4;
            this.tabView1.Text = "radPageView1";
            this.tabView1.ThemeName = "Windows8";
            this.tabView1.ViewMode = Telerik.WinControls.UI.PageViewMode.Stack;
            ((Telerik.WinControls.UI.RadPageViewStackElement)(this.tabView1.GetChildAt(0))).StackPosition = Telerik.WinControls.UI.StackViewPosition.Top;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Numberry.Properties.Resources.telephone;
            this.pictureBox1.Location = new System.Drawing.Point(298, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 386);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabView1);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            ((System.ComponentModel.ISupportInitialize)(this.buttonWrite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonDisconnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonConnect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabView1)).EndInit();
            this.tabView1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Windows8Theme windows8Theme1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage3;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage2;
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
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
