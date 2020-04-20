using System;
using System.Windows.Forms;


namespace ScreenCap
{
    // Job types
    public enum DelayedCaptureJobType
    {
        Record,
        Shoot,
        JobDone
    }

    // Class to handle times screenshots
    public class DelayedCaptureJob
    {
        public DelayedCaptureJobType my_job_type;
        public int time_left;
        public main_form my_form;
        private Timer my_timer;
        private bool disposed = false;

        public DelayedCaptureJob(DelayedCaptureJobType in_job_type, int in_time_left, main_form in_form)
        {
            this.my_job_type = in_job_type;
            // +1 because calling first tick instant
            this.time_left = in_time_left + 1;
            this.my_form = in_form;
            this.my_timer = new Timer();
            this.my_timer.Interval = 1000;
            this.my_timer.Tick += this.tick;
            this.set_form_enabled(false);
            this.tick(null,null);
            ;
        }

        // enabled/disable form
        private void set_form_enabled(bool is_enabled)
        {
            this.my_form.delayed_screenshot_set_form_enabled(is_enabled);
        }

        // execute the screenshot/recording
        private void do_job()
        {
            switch (this.my_job_type)
            {
                case DelayedCaptureJobType.Record:
                    this.my_form.btn_gif_record_Click(this, null);
                    break;
                case DelayedCaptureJobType.Shoot:
                    this.my_form.btn_screenshot_Click(this, null);
                    break;
                case DelayedCaptureJobType.JobDone:
                    throw new InvalidOperationException("Calling dead Job");
            }
        }

        // timer tick
        public void tick(object sender, EventArgs e)
        {
            if(this.my_job_type == DelayedCaptureJobType.JobDone)
            {
                throw new InvalidOperationException("Calling dead Job");
            }
            
            this.time_left--;
            if (this.time_left <= 0)
            {
                this.do_job();
                this.set_form_enabled(true);
                this.my_timer.Enabled = false;
                this.my_form.set_btn_delay_cancel_text("cancel");
            }
            else
            {
                this.my_timer.Enabled = true;
                this.my_form.set_btn_delay_cancel_text("cancel (left: " + this.time_left.ToString() + " sec)");
            }
            this.my_form.do_events();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.set_form_enabled(true);
                    this.my_form.set_btn_delay_cancel_text("cancel");
                    this.my_timer.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
