using System;
using System.Drawing;
using System.Windows.Forms;

namespace MediManage
{
    public class CustomCheckBox : CheckBox
    {
        public CustomCheckBox()
        {
            // إلغاء أنماط النظام الافتراضية
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            // تفعيل الرسم الخاص وإلغاء رسم النظام
            this.SetStyle(ControlStyles.UserPaint |
                           ControlStyles.AllPaintingInWmPaint |
                           ControlStyles.OptimizedDoubleBuffer |
                           ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 1. مسح الخلفية بلون الأب (Form/Panel)
            Color backColor = this.Parent != null ? this.Parent.BackColor : this.BackColor;
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            // 2. تحديد أبعاد المربع بنفس أبعادك (الخصم 1 بكسل للنظافة)
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            // 3. رسم خلفية المربع باللون الأبيض
            e.Graphics.FillRectangle(Brushes.White, rect);

            // 4. رسم حدود المربع باللون الرمادي
            using (Pen pen = new Pen(Color.DarkGray, 2))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }

            // 5. رسم علامة الصح بنفس إحداثياتك عند التفعيل
            if (this.Checked)
            {
                using (Pen checkPen = new Pen(Color.DarkRed, 3))
                {
                    e.Graphics.DrawLine(checkPen, rect.Width * 0.25f, rect.Height * 0.5f, rect.Width * 0.45f, rect.Height * 0.75f);
                    e.Graphics.DrawLine(checkPen, rect.Width * 0.45f, rect.Height * 0.75f, rect.Width * 0.85f, rect.Height * 0.25f);
                }
            }
        }
    }
}