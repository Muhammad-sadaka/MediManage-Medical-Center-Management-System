using System;
using System.Drawing;
using System.Windows.Forms;

namespace MediManage
{
    public partial class MyCustomCheckBox : CheckBox
    {
        public MyCustomCheckBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 1. مسح الرسمة الافتراضية الصغيرة للنظام
            e.Graphics.Clear(this.BackColor);

            // 2. تحديد حجم المربع الأبيض ليكون بحجم العنصر كاملاً
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            // 3. رسم خلفية المربع باللون الأبيض
            e.Graphics.FillRectangle(Brushes.White, rect);

            // 4. رسم حدود المربع (Border) باللون الرمادي
            using (Pen pen = new Pen(Color.DarkGray, 2))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }

            // 5. إذا قام المستخدم بالضغط عليه واختياره (Checked)، ارسم علامة الصح بالداخل
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