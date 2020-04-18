using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace ScreenCap
{
    public partial class frm_select_area : Form
    {
        private ScreenCap.main_form parent;

        public frm_select_area(ScreenCap.main_form myparent)
        {
            InitializeComponent();
            this.parent = myparent;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private const int cGrip = 16;      // Grip size

        protected override void OnPaint(PaintEventArgs e)
        {
            // Grip
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);

            rc = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            e.Graphics.FillRectangle(Brushes.Transparent, rc);

            // Border
            Pen pen = new Pen(Color.Black, 2);
            pen.Alignment = PenAlignment.Inset; //<-- this
            e.Graphics.DrawRectangle(pen, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                System.Drawing.Point pos = new System.Drawing.Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                /*
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                */
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
                else
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
            }
            base.WndProc(ref m);
        }


        /*
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        */
    }
}
