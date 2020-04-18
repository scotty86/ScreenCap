namespace ScreenCap
{
    partial class main_form
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.pic_preview = new System.Windows.Forms.PictureBox();
            this.btn_screenshot = new System.Windows.Forms.Button();
            this.grp_cap_area = new System.Windows.Forms.GroupBox();
            this.rad_capture_area = new System.Windows.Forms.RadioButton();
            this.rad_capture_screen = new System.Windows.Forms.RadioButton();
            this.grp_gif = new System.Windows.Forms.GroupBox();
            this.txt_gif_fps = new System.Windows.Forms.TextBox();
            this.lab_gif_fps = new System.Windows.Forms.Label();
            this.lab_gif_length_seconds = new System.Windows.Forms.Label();
            this.txt_gif_length_seconds = new System.Windows.Forms.TextBox();
            this.btn_gif_record = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_copy_image = new System.Windows.Forms.Button();
            this.saveDialog_image = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pic_preview)).BeginInit();
            this.grp_cap_area.SuspendLayout();
            this.grp_gif.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_preview
            // 
            this.pic_preview.Location = new System.Drawing.Point(12, 12);
            this.pic_preview.Name = "pic_preview";
            this.pic_preview.Size = new System.Drawing.Size(548, 320);
            this.pic_preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_preview.TabIndex = 0;
            this.pic_preview.TabStop = false;
            // 
            // btn_screenshot
            // 
            this.btn_screenshot.Location = new System.Drawing.Point(12, 396);
            this.btn_screenshot.Name = "btn_screenshot";
            this.btn_screenshot.Size = new System.Drawing.Size(188, 23);
            this.btn_screenshot.TabIndex = 1;
            this.btn_screenshot.Text = "Take picture";
            this.btn_screenshot.UseVisualStyleBackColor = true;
            this.btn_screenshot.Click += new System.EventHandler(this.btn_screenshot_Click);
            // 
            // grp_cap_area
            // 
            this.grp_cap_area.Controls.Add(this.rad_capture_area);
            this.grp_cap_area.Controls.Add(this.rad_capture_screen);
            this.grp_cap_area.Location = new System.Drawing.Point(12, 338);
            this.grp_cap_area.Name = "grp_cap_area";
            this.grp_cap_area.Size = new System.Drawing.Size(188, 52);
            this.grp_cap_area.TabIndex = 3;
            this.grp_cap_area.TabStop = false;
            this.grp_cap_area.Text = "Capture-Area";
            // 
            // rad_capture_area
            // 
            this.rad_capture_area.AutoSize = true;
            this.rad_capture_area.Location = new System.Drawing.Point(89, 19);
            this.rad_capture_area.Name = "rad_capture_area";
            this.rad_capture_area.Size = new System.Drawing.Size(89, 17);
            this.rad_capture_area.TabIndex = 1;
            this.rad_capture_area.Text = "selected area";
            this.rad_capture_area.UseVisualStyleBackColor = true;
            this.rad_capture_area.CheckedChanged += new System.EventHandler(this.rad_capture_area_CheckedChanged);
            // 
            // rad_capture_screen
            // 
            this.rad_capture_screen.AutoSize = true;
            this.rad_capture_screen.Checked = true;
            this.rad_capture_screen.Location = new System.Drawing.Point(10, 19);
            this.rad_capture_screen.Name = "rad_capture_screen";
            this.rad_capture_screen.Size = new System.Drawing.Size(73, 17);
            this.rad_capture_screen.TabIndex = 0;
            this.rad_capture_screen.TabStop = true;
            this.rad_capture_screen.Text = "full screen";
            this.rad_capture_screen.UseVisualStyleBackColor = true;
            this.rad_capture_screen.CheckedChanged += new System.EventHandler(this.rad_capture_screen_CheckedChanged);
            // 
            // grp_gif
            // 
            this.grp_gif.Controls.Add(this.txt_gif_fps);
            this.grp_gif.Controls.Add(this.lab_gif_fps);
            this.grp_gif.Controls.Add(this.lab_gif_length_seconds);
            this.grp_gif.Controls.Add(this.txt_gif_length_seconds);
            this.grp_gif.Controls.Add(this.btn_gif_record);
            this.grp_gif.Location = new System.Drawing.Point(206, 338);
            this.grp_gif.Name = "grp_gif";
            this.grp_gif.Size = new System.Drawing.Size(354, 81);
            this.grp_gif.TabIndex = 4;
            this.grp_gif.TabStop = false;
            this.grp_gif.Text = "GIF-Recording";
            // 
            // txt_gif_fps
            // 
            this.txt_gif_fps.Location = new System.Drawing.Point(148, 47);
            this.txt_gif_fps.Name = "txt_gif_fps";
            this.txt_gif_fps.Size = new System.Drawing.Size(69, 20);
            this.txt_gif_fps.TabIndex = 4;
            this.txt_gif_fps.Text = "10";
            // 
            // lab_gif_fps
            // 
            this.lab_gif_fps.AutoSize = true;
            this.lab_gif_fps.Location = new System.Drawing.Point(7, 50);
            this.lab_gif_fps.Name = "lab_gif_fps";
            this.lab_gif_fps.Size = new System.Drawing.Size(100, 13);
            this.lab_gif_fps.TabIndex = 3;
            this.lab_gif_fps.Text = "Frames per second:";
            // 
            // lab_gif_length_seconds
            // 
            this.lab_gif_length_seconds.AutoSize = true;
            this.lab_gif_length_seconds.Location = new System.Drawing.Point(7, 25);
            this.lab_gif_length_seconds.Name = "lab_gif_length_seconds";
            this.lab_gif_length_seconds.Size = new System.Drawing.Size(135, 13);
            this.lab_gif_length_seconds.TabIndex = 2;
            this.lab_gif_length_seconds.Text = "Recording time in seconds:";
            // 
            // txt_gif_length_seconds
            // 
            this.txt_gif_length_seconds.Location = new System.Drawing.Point(148, 21);
            this.txt_gif_length_seconds.Name = "txt_gif_length_seconds";
            this.txt_gif_length_seconds.Size = new System.Drawing.Size(69, 20);
            this.txt_gif_length_seconds.TabIndex = 1;
            this.txt_gif_length_seconds.Text = "5";
            // 
            // btn_gif_record
            // 
            this.btn_gif_record.Location = new System.Drawing.Point(223, 18);
            this.btn_gif_record.Name = "btn_gif_record";
            this.btn_gif_record.Size = new System.Drawing.Size(125, 49);
            this.btn_gif_record.TabIndex = 0;
            this.btn_gif_record.Text = "Record";
            this.btn_gif_record.UseVisualStyleBackColor = true;
            this.btn_gif_record.Click += new System.EventHandler(this.btn_gif_record_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(12, 425);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(271, 23);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "save Image";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_copy_image
            // 
            this.btn_copy_image.Location = new System.Drawing.Point(289, 425);
            this.btn_copy_image.Name = "btn_copy_image";
            this.btn_copy_image.Size = new System.Drawing.Size(271, 23);
            this.btn_copy_image.TabIndex = 6;
            this.btn_copy_image.Text = "copy image to clipboard";
            this.btn_copy_image.UseVisualStyleBackColor = true;
            this.btn_copy_image.Click += new System.EventHandler(this.btn_copy_image_Click);
            // 
            // saveDialog_image
            // 
            this.saveDialog_image.FileOk += new System.ComponentModel.CancelEventHandler(this.saveDialog_image_FileOK);
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 463);
            this.Controls.Add(this.btn_copy_image);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.grp_gif);
            this.Controls.Add(this.grp_cap_area);
            this.Controls.Add(this.btn_screenshot);
            this.Controls.Add(this.pic_preview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "main_form";
            this.Text = "ScreenCap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.main__form_FormClosing);
            this.Load += new System.EventHandler(this.main_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_preview)).EndInit();
            this.grp_cap_area.ResumeLayout(false);
            this.grp_cap_area.PerformLayout();
            this.grp_gif.ResumeLayout(false);
            this.grp_gif.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_preview;
        private System.Windows.Forms.Button btn_screenshot;
        private System.Windows.Forms.GroupBox grp_cap_area;
        private System.Windows.Forms.RadioButton rad_capture_area;
        private System.Windows.Forms.RadioButton rad_capture_screen;
        private System.Windows.Forms.GroupBox grp_gif;
        private System.Windows.Forms.TextBox txt_gif_fps;
        private System.Windows.Forms.Label lab_gif_fps;
        private System.Windows.Forms.Label lab_gif_length_seconds;
        private System.Windows.Forms.TextBox txt_gif_length_seconds;
        private System.Windows.Forms.Button btn_gif_record;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_copy_image;
        private System.Windows.Forms.SaveFileDialog saveDialog_image;
    }
}

