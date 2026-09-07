using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediManage
{
    public partial class MyCustomCheckBox : CheckBox
    {
        public MyCustomCheckBox()
        {
            InitializeComponent();
        }

        private void checkBox1_Paint_1(object sender, PaintEventArgs e)
        {
            // 1. مسح الرسمة الافتراضية الصغيرة للنظام
            e.Graphics.Clear(this.checkBox1.BackColor);

            // 2. تحديد حجم المربع الأبيض ليكون بحجم العنصر كاملاً (مثلاً 25x25)
            // قمنا بخصم 1 بكسل للحفاظ على الحدود نظيفة
            Rectangle rect = new Rectangle(0, 0, this.checkBox1.Width - 1, this.checkBox1.Height - 1);

            // 3. رسم خلفية المربع باللون الأبيض
            e.Graphics.FillRectangle(Brushes.White, rect);

            // 4. رسم حدود المربع (Border) باللون الرمادي أو الأزرق
            using (Pen pen = new Pen(Color.DarkGray, 2))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }

            // 5. إذا قام المستخدم بالضغط عليه واختياره (Checked)، ارسم علامة الصح بالداخل
            if (this.checkBox1.Checked)
            {
                using (Pen checkPen = new Pen(Color.DarkRed, 3)) // لون وحجم خط علامة الصح
                {
                    // رسم علامة الصح يدوياً لتناسب أي حجم تكبر إليه خانة الاختيار
                    e.Graphics.DrawLine(checkPen, rect.Width * 0.25f, rect.Height * 0.5f, rect.Width * 0.45f, rect.Height * 0.75f);
                    e.Graphics.DrawLine(checkPen, rect.Width * 0.45f, rect.Height * 0.75f, rect.Width * 0.85f, rect.Height * 0.25f);
                }
            }
        }
    }
}
