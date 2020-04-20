using GifMotion;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ScreenCap
{
    public partial class main_form : Form
    {
        private frm_select_area frm_select_area_instance;
        private bool current_image_is_gif = false;
        private String tmp_gif_path = Application.StartupPath + "\\tmp.gif";
        private DelayedCaptureJob curr_delayed_capture_job;

        public main_form()
        {
            InitializeComponent();
            frm_select_area_instance = new frm_select_area(this);
        }

        public void btn_screenshot_Click(object sender, EventArgs e)
        {
            if(chk_delayed_shot.Checked && !(sender is DelayedCaptureJob)){
                this.start_delayed_job(DelayedCaptureJobType.Shoot);
                return;
            }

            if (this.rad_capture_screen.Checked)
            {
                pic_preview.Image = this.take_snapshot_screen();
            }
            if (this.rad_capture_area.Checked)
            {
                pic_preview.Image = this.take_snapshot_area();
            }
            current_image_is_gif = false;
            rad_capture_screen.Checked = true;
        }

        private void main_form_Load(object sender, EventArgs e)
        {
            
        }

        private void main__form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Delete temp files
            if(File.Exists(tmp_gif_path))
            {
                File.Delete(tmp_gif_path);
            }
        }

        // Set picture on main form
        public void setPic(Image inPic)
        {
            this.pic_preview.Image = inPic;
        }

        // show/hide capture frame
        private void capture_area_change()
        {
            if(this.rad_capture_screen.Checked)
            {
                frm_select_area_instance.Hide();
            }
            if (this.rad_capture_area.Checked)
            {
                frm_select_area_instance.Show();
            }
        }

        private void rad_capture_screen_CheckedChanged(object sender, EventArgs e)
        {
            capture_area_change();
        }

        private void rad_capture_area_CheckedChanged(object sender, EventArgs e)
        {
            capture_area_change();
        }

        // take snapshot of screen
        private Bitmap take_snapshot_screen()
        {
            return this.take_snapshot(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        // take snapshot of area
        private Bitmap take_snapshot_area()
        {
            var org_opt = frm_select_area_instance.Opacity;
            frm_select_area_instance.Opacity = 0;
            Bitmap tmp_image = this.take_snapshot(frm_select_area_instance.Bounds.X, frm_select_area_instance.Bounds.Y, frm_select_area_instance.Size.Width, frm_select_area_instance.Size.Height);
            frm_select_area_instance.Opacity = org_opt;
            return tmp_image;
        }

        // snapshot function
        private Bitmap take_snapshot(int x, int y, int w, int h)
        {
            Size shot_size = new Size(w, h);
            var bmpScreenshot = new Bitmap(w,
                                           h,
                                           PixelFormat.Format32bppArgb);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(x,
                                        y,
                                        0,
                                        0,
                                        shot_size,
                                        CopyPixelOperation.SourceCopy);
            return bmpScreenshot;
        }

        // load an image file into picturebox without keeping a lock on the file
        private void load_external_image(String img_path)
        {
            PictureBox pic = this.pic_preview;
            using (var fs = new System.IO.FileStream(img_path, System.IO.FileMode.Open))
            {
                var ms = new System.IO.MemoryStream();
                fs.CopyTo(ms);
                ms.Position = 0;                               // <=== here
                if (pic.Image != null) pic.Image.Dispose();
                pic.Image = Image.FromStream(ms);
            }
        }

        public void btn_gif_record_Click(object sender, EventArgs e)
        {
            if (chk_delayed_shot.Checked && !(sender is DelayedCaptureJob))
            {
                this.start_delayed_job(DelayedCaptureJobType.Record);
                return;
            }

            Application.DoEvents();

            int x = 0, y = 0, w = 0, h = 0;

            if (rad_capture_screen.Checked)
            {
                x = Screen.PrimaryScreen.Bounds.X;
                y = Screen.PrimaryScreen.Bounds.Y;
                w = Screen.PrimaryScreen.Bounds.Width;
                h = Screen.PrimaryScreen.Bounds.Height;
            }

            if (rad_capture_area.Checked)
            {
                x = frm_select_area_instance.Bounds.X;
                y = frm_select_area_instance.Bounds.Y;
                w = frm_select_area_instance.Bounds.Width;
                h = frm_select_area_instance.Bounds.Height;

                frm_select_area_instance.Hide();
            }

            int seconds_to_record = Int32.Parse(this.txt_gif_length_seconds.Text);
            int fps = Int32.Parse(this.txt_gif_fps.Text);
            int i = 0;

            // total amount of pictures
            int picture_count = seconds_to_record * fps;
            // delay between each screenshot
            int mysleep = 1000 / fps;
            // temp storage for screenshots
            Image[] screenshots = new Image[picture_count];

            // take screenshots
            while (i < picture_count)
            {
                screenshots[i] = this.take_snapshot(x, y, w, h);
                i++;
                System.Threading.Thread.Sleep(mysleep);
            }
            
            // generate the gif and store it as temp file
            using (GifCreator gifCreator = AnimatedGif.Create(this.tmp_gif_path, mysleep))
            {
                foreach (Image screenshot in screenshots)
                {
                    using (screenshot)
                    {
                        gifCreator.AddFrame(screenshot);
                    }
                }
            }

            // load the gif temp file to picture box
            this.load_external_image(this.tmp_gif_path);;

            // reset form and set gif var
            if (rad_capture_area.Checked) {
                    frm_select_area_instance.Show();
            }

            current_image_is_gif = true;
                rad_capture_screen.Checked = true;
            
        }

        // copy taken pictures to clipboard (GIF not possible so far, it will only copy one frame)
        private void btn_copy_image_Click(object sender, EventArgs e)
        {
            if (pic_preview.Image == null)
            {
                MessageBox.Show("Please take a picture first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.current_image_is_gif)
            {
                MessageBox.Show("Sorry, a GIF can't be copied :((");
            }
            else
            {
                Clipboard.SetImage(this.pic_preview.Image);
                MessageBox.Show("Image copied :)");
            }
        }

        // build save dialog
        private void btn_save_Click(object sender, EventArgs e)
        {
            if(pic_preview.Image == null)
            {
                MessageBox.Show("Please take a picture first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.current_image_is_gif)
            {
                saveDialog_image.Filter = "GIF Files(*.GIF)|*.GIF";
                saveDialog_image.ShowDialog();
            }
            else
            {
                saveDialog_image.Filter = "PNG Image(*.PNG)|*.PNG|JPG Files(*.JPG;*.JPEG)|*.JPG;*.JPEG|BMP Files(*.BMP)|*.BMP";
                saveDialog_image.ShowDialog();
            }
        }

        // save pictures to disk
        private void saveDialog_image_FileOK(object sender, CancelEventArgs e)
        {
            // copy gif temp file to location
            if (this.current_image_is_gif)
            {
                File.Copy(tmp_gif_path, saveDialog_image.FileName);
            }
            else
            {
                // save image in selected format to given location
                ImageFormat new_img_format = null;
                switch (saveDialog_image.FilterIndex)
                {
                    // PNG
                    case 1:
                        new_img_format = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    // JPG
                    case 2:
                        new_img_format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    // BMP
                    case 3:
                        new_img_format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                }
                pic_preview.Image.Save(saveDialog_image.FileName, new_img_format);
            }
        }

        // enable/disable form
        public void delayed_screenshot_set_form_enabled(bool is_enabled)
        {
                this.grp_cap_area.Enabled = is_enabled;
                this.chk_delayed_shot.Enabled = is_enabled;
                this.lab_delay.Enabled = is_enabled;
                this.txt_delay.Enabled = is_enabled;
                this.btn_delay_cancel.Enabled = !is_enabled;
                this.btn_screenshot.Enabled = is_enabled;
                this.grp_gif.Enabled = is_enabled;
                this.btn_save.Enabled = is_enabled;
                this.btn_copy_image.Enabled = is_enabled;
        }

        // function to access button text
        public void set_btn_delay_cancel_text(String in_string)
        {
                this.btn_delay_cancel.Text = in_string;
        }

        // guess what
        public void do_events()
        {
            Application.DoEvents();
        }

        // create and start a timed/delayed screenshot
        private void start_delayed_job(DelayedCaptureJobType job_type)
        {
            if (this.curr_delayed_capture_job != null)
            {
                this.curr_delayed_capture_job.Dispose();
                this.curr_delayed_capture_job = null;
            }
            this.curr_delayed_capture_job = new DelayedCaptureJob(job_type, Int32.Parse(txt_delay.Text), this);
        }

        private void btn_delay_cancel_Click(object sender, EventArgs e)
        {
            this.curr_delayed_capture_job.Dispose();
            this.curr_delayed_capture_job = null;
        }
    }
}
