using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MediManage.Controls
{
    [DefaultEvent("TextChanged")]
    public partial class CustomTextBox : UserControl
    {
        private TextBox textBox1;
        private Color borderColor = Color.Maroon;
        private int borderRadius = 15;
        private int borderWidth = 2;

        public CustomTextBox()
        {
            InitializeComponent();

            this.Size = new Size(250, 40);
            this.BackColor = Color.White;
            this.DoubleBuffered = true;

            textBox1 = new TextBox();
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 11F);
            textBox1.BackColor = this.BackColor;

            // التوسيط الأفقي الافتراضي (يمكن تغييره من الـ Properties)
            textBox1.TextAlign = HorizontalAlignment.Center;

            // ضبط الموقع ليكون في المنتصف تماماً عمودياً
            UpdateTextBoxPosition();

            // ربط الأحداث
            textBox1.TextChanged += (s, e) => this.OnTextChanged(e);
            textBox1.Enter += (s, e) => this.OnEnter(e);
            textBox1.Leave += (s, e) => this.OnLeave(e);

            this.Controls.Add(textBox1);
        }

        private void UpdateTextBoxPosition()
        {
            if (textBox1 != null)
            {
                // حساب المنتصف عمودياً بدقة بناءً على ارتفاع الخط
                int topMargin = (this.Height - textBox1.Height) / 2;
                textBox1.Location = new Point(15, Math.Max(topMargin, 6));
                textBox1.Width = this.Width - 30; // ترك هامش متساوي يمين ويسار
            }
        }

        #region Properties (الخصائص)

        [Category("Custom Properties")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public override string Text
        {
            get => textBox1.Text;
            set { textBox1.Text = value; this.Invalidate(); }
        }

        [Category("Custom Properties")]
        public HorizontalAlignment TextAlign
        {
            get => textBox1.TextAlign;
            set => textBox1.TextAlign = value;
        }

        [Category("Custom Properties")]
        public char PasswordChar
        {
            get => textBox1.PasswordChar;
            set => textBox1.PasswordChar = value;
        }

        [Category("Custom Properties")]
        public bool UseSystemPasswordChar
        {
            get => textBox1.UseSystemPasswordChar;
            set => textBox1.UseSystemPasswordChar = value;
        }

        [Category("Custom Properties")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; this.Invalidate(); }
        }

        [Category("Custom Properties")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; this.Invalidate(); }
        }

        [Category("Custom Properties")]
        public int BorderSize
        {
            get => borderWidth;
            set { borderWidth = value; this.Invalidate(); }
        }

        [Category("Custom Properties")]
        public override Color ForeColor
        {
            get => textBox1.ForeColor;
            set { base.ForeColor = value; textBox1.ForeColor = value; }
        }

        [Category("Custom Properties")]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                if (textBox1 != null) textBox1.Font = value;
                UpdateTextBoxPosition();
            }
        }

        [Browsable(false)]
        public TextBox InnerTextBox => textBox1;

        #endregion

        #region رسم الحواف

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            using (GraphicsPath path = GetRoundedPath(rect, borderRadius))
            {
                this.Region = new Region(path);

                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateTextBoxPosition();
            this.Invalidate();
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.Left, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();

            return path;
        }

        #endregion
    }
}