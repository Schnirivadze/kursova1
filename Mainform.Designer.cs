namespace Kurs
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
#pragma warning disable CS0414
		private System.ComponentModel.IContainer components = null;
#pragma warning restore CS0414
		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.MoviesPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.Filters = new System.Windows.Forms.GroupBox();
			this.GenreComboBox = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.ActorTextBox = new System.Windows.Forms.TextBox();
			this.SearchButton = new System.Windows.Forms.Button();
			this.TitleTextBox = new System.Windows.Forms.TextBox();
			this.DirectorTextBox = new System.Windows.Forms.TextBox();
			this.StudioTextBox = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.сортуватиЗаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.аЯToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.аЯToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.оцінкоюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.розміромбільщіСпочаткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.розміромменщіСпочаткуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.новизнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.допомогаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.Filters.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// MoviesPanel
			// 
			this.MoviesPanel.AutoScroll = true;
			this.MoviesPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.MoviesPanel.Location = new System.Drawing.Point(315, 30);
			this.MoviesPanel.Name = "MoviesPanel";
			this.MoviesPanel.Size = new System.Drawing.Size(945, 640);
			this.MoviesPanel.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.Filters);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(315, 670);
			this.panel1.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label6.Location = new System.Drawing.Point(14, 638);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(283, 26);
			this.label6.TabIndex = 10;
			this.label6.Text = "Розробив Селезньов Андрій 2024";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Filters
			// 
			this.Filters.Controls.Add(this.GenreComboBox);
			this.Filters.Controls.Add(this.label8);
			this.Filters.Controls.Add(this.label3);
			this.Filters.Controls.Add(this.label1);
			this.Filters.Controls.Add(this.label4);
			this.Filters.Controls.Add(this.label5);
			this.Filters.Controls.Add(this.ActorTextBox);
			this.Filters.Controls.Add(this.SearchButton);
			this.Filters.Controls.Add(this.TitleTextBox);
			this.Filters.Controls.Add(this.DirectorTextBox);
			this.Filters.Controls.Add(this.StudioTextBox);
			this.Filters.Font = new System.Drawing.Font("FiraMono Nerd Font", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Filters.Location = new System.Drawing.Point(17, 129);
			this.Filters.Name = "Filters";
			this.Filters.Size = new System.Drawing.Size(280, 506);
			this.Filters.TabIndex = 1;
			this.Filters.TabStop = false;
			this.Filters.Text = "Фільтри ";
			// 
			// GenreComboBox
			// 
			this.GenreComboBox.FormattingEnabled = true;
			this.GenreComboBox.Items.AddRange(new object[] {
			"Action",
			"Adventure",
			"Comedy",
			"Drama",
			"Horror",
			"Science Fiction (Sci-Fi)",
			"Fantasy",
			"Thriller",
			"Romance",
			"Animation",
			"Mystery",
			"Crime",
			"Family",
			"Musical",
			"Historical",
			"War",
			"Documentary",
			"Biographical",
			"Sport"});
			this.GenreComboBox.Location = new System.Drawing.Point(34, 180);
			this.GenreComboBox.Name = "GenreComboBox";
			this.GenreComboBox.Size = new System.Drawing.Size(203, 24);
			this.GenreComboBox.TabIndex = 3;
			this.GenreComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownHandler);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(31, 281);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(119, 16);
			this.label8.TabIndex = 12;
			this.label8.Text = "Головні актори";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(31, 221);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Режисер";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(31, 101);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Студія";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(31, 161);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Жанр";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(31, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(47, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Назва";
			// 
			// ActorTextBox
			// 
			this.ActorTextBox.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.ActorTextBox.Location = new System.Drawing.Point(34, 300);
			this.ActorTextBox.Name = "ActorTextBox";
			this.ActorTextBox.Size = new System.Drawing.Size(203, 23);
			this.ActorTextBox.TabIndex = 5;
			this.ActorTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownHandler);
			// 
			// SearchButton
			// 
			this.SearchButton.Location = new System.Drawing.Point(63, 456);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(148, 28);
			this.SearchButton.TabIndex = 6;
			this.SearchButton.Text = "Шукати";
			this.SearchButton.UseVisualStyleBackColor = true;
			this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
			// 
			// TitleTextBox
			// 
			this.TitleTextBox.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.TitleTextBox.Location = new System.Drawing.Point(34, 60);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.Size = new System.Drawing.Size(203, 23);
			this.TitleTextBox.TabIndex = 1;
			this.TitleTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownHandler);
			// 
			// DirectorTextBox
			// 
			this.DirectorTextBox.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.DirectorTextBox.Location = new System.Drawing.Point(34, 240);
			this.DirectorTextBox.Name = "DirectorTextBox";
			this.DirectorTextBox.Size = new System.Drawing.Size(203, 23);
			this.DirectorTextBox.TabIndex = 4;
			this.DirectorTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownHandler);
			// 
			// StudioTextBox
			// 
			this.StudioTextBox.Font = new System.Drawing.Font("Cascadia Code", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.StudioTextBox.Location = new System.Drawing.Point(34, 120);
			this.StudioTextBox.Name = "StudioTextBox";
			this.StudioTextBox.Size = new System.Drawing.Size(203, 23);
			this.StudioTextBox.TabIndex = 2;
			this.StudioTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownHandler);
			// 
			// panel2
			// 
			this.panel2.BackgroundImage = global::Kurs.Properties.Resources._1716313431827;
			this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel2.Location = new System.Drawing.Point(17, -50);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(280, 249);
			this.panel2.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.сортуватиЗаToolStripMenuItem,
			this.допомогаToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(945, 28);
			this.menuStrip1.TabIndex = 11;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// сортуватиЗаToolStripMenuItem
			// 
			this.сортуватиЗаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.аЯToolStripMenuItem,
			this.аЯToolStripMenuItem1,
			this.оцінкоюToolStripMenuItem,
			this.розміромбільщіСпочаткуToolStripMenuItem,
			this.розміромменщіСпочаткуToolStripMenuItem,
			this.новизнаToolStripMenuItem});
			this.сортуватиЗаToolStripMenuItem.Name = "сортуватиЗаToolStripMenuItem";
			this.сортуватиЗаToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
			this.сортуватиЗаToolStripMenuItem.Text = "Сортувати за";
			// 
			// аЯToolStripMenuItem
			// 
			this.аЯToolStripMenuItem.Name = "аЯToolStripMenuItem";
			this.аЯToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
			this.аЯToolStripMenuItem.Text = "А-Я";
			this.аЯToolStripMenuItem.Click += new System.EventHandler(this.аЯToolStripMenuItem_Click);
			// 
			// аЯToolStripMenuItem1
			// 
			this.аЯToolStripMenuItem1.Name = "аЯToolStripMenuItem1";
			this.аЯToolStripMenuItem1.Size = new System.Drawing.Size(284, 26);
			this.аЯToolStripMenuItem1.Text = "Я-А";
			this.аЯToolStripMenuItem1.Click += new System.EventHandler(this.аЯToolStripMenuItem1_Click);
			// 
			// оцінкоюToolStripMenuItem
			// 
			this.оцінкоюToolStripMenuItem.Name = "оцінкоюToolStripMenuItem";
			this.оцінкоюToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
			this.оцінкоюToolStripMenuItem.Text = "Оцінкою";
			this.оцінкоюToolStripMenuItem.Click += new System.EventHandler(this.оцінкоюToolStripMenuItem_Click);
			// 
			// розміромбільщіСпочаткуToolStripMenuItem
			// 
			this.розміромбільщіСпочаткуToolStripMenuItem.Name = "розміромбільщіСпочаткуToolStripMenuItem";
			this.розміромбільщіСпочаткуToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
			this.розміромбільщіСпочаткуToolStripMenuItem.Text = "Розміром (більщі спочатку)";
			this.розміромбільщіСпочаткуToolStripMenuItem.Click += new System.EventHandler(this.розміромбільщіСпочаткуToolStripMenuItem_Click);
			// 
			// розміромменщіСпочаткуToolStripMenuItem
			// 
			this.розміромменщіСпочаткуToolStripMenuItem.Name = "розміромменщіСпочаткуToolStripMenuItem";
			this.розміромменщіСпочаткуToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
			this.розміромменщіСпочаткуToolStripMenuItem.Text = "Розміром (менщі спочатку)";
			this.розміромменщіСпочаткуToolStripMenuItem.Click += new System.EventHandler(this.розміромменщіСпочаткуToolStripMenuItem_Click);
			// 
			// новизнаToolStripMenuItem
			// 
			this.новизнаToolStripMenuItem.Name = "новизнаToolStripMenuItem";
			this.новизнаToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
			this.новизнаToolStripMenuItem.Text = "Новизна";
			this.новизнаToolStripMenuItem.Click += new System.EventHandler(this.новизнаToolStripMenuItem_Click);
			// 
			// допомогаToolStripMenuItem
			// 
			this.допомогаToolStripMenuItem.Name = "допомогаToolStripMenuItem";
			this.допомогаToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
			this.допомогаToolStripMenuItem.Text = "Допомога";
			this.допомогаToolStripMenuItem.Click += new System.EventHandler(this.допомогаToolStripMenuItem_Click);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Gainsboro;
			this.panel3.Controls.Add(this.menuStrip1);
			this.panel3.Location = new System.Drawing.Point(315, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(945, 30);
			this.panel3.TabIndex = 2;
			// 
			// Mainform
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1262, 673);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.MoviesPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Mainform";
			this.ShowIcon = false;
			this.Text = "Main Page";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDownHandler);
			this.panel1.ResumeLayout(false);
			this.Filters.ResumeLayout(false);
			this.Filters.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel MoviesPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox Filters;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox StudioTextBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox DirectorTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox TitleTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button SearchButton;
		private System.Windows.Forms.TextBox ActorTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem сортуватиЗаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem аЯToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem аЯToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem оцінкоюToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem розміромбільщіСпочаткуToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem розміромменщіСпочаткуToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem новизнаToolStripMenuItem;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ComboBox GenreComboBox;
		private System.Windows.Forms.ToolStripMenuItem допомогаToolStripMenuItem;
	}
}

