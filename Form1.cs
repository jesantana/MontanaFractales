using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Materiales;

	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
		private Scene scene;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			scene = new Scene();
			scene.redraw += new EventHandler(scene_redraw);
			
			InitializeComponent();
			
			for(int i=1;i<15;i++)
			{
			listBox1.Items.Add(i);
			}
			listBox1.SetSelected(8,true);
			listBox2.SetSelected(0,true);
			simpleOpenGlControl1.InitializeContexts();
			scene.Initialize();
			scene.element=new MontanaFractal((int)listBox1.SelectedItem,listBox2.SelectedIndex+1)/*new Text()*/;/*new Ortoedro(new Point3D(-2,1.5,-10),4,3,2,new float[3]{0.3f,0.7f,0.9f});*/
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// simpleOpenGlControl1
			// 
			this.simpleOpenGlControl1.AccumBits = ((System.Byte)(0));
			this.simpleOpenGlControl1.AutoCheckErrors = false;
			this.simpleOpenGlControl1.AutoFinish = false;
			this.simpleOpenGlControl1.AutoMakeCurrent = true;
			this.simpleOpenGlControl1.AutoSwapBuffers = true;
			this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Black;
			this.simpleOpenGlControl1.ColorBits = ((System.Byte)(32));
			this.simpleOpenGlControl1.DepthBits = ((System.Byte)(16));
			this.simpleOpenGlControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.simpleOpenGlControl1.Location = new System.Drawing.Point(0, 0);
			this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
			this.simpleOpenGlControl1.Size = new System.Drawing.Size(632, 446);
			this.simpleOpenGlControl1.StencilBits = ((System.Byte)(0));
			this.simpleOpenGlControl1.TabIndex = 0;
			this.simpleOpenGlControl1.Resize += new System.EventHandler(this.simpleOpenGlControl1_Resize);
			this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
			this.simpleOpenGlControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.simpleOpenGlControl1_KeyDown);
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(8, 24);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(96, 69);
			this.listBox1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(360, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 24);
			this.button1.TabIndex = 2;
			this.button1.Text = "Generar Montanna";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(0, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Nivel del algoritmo";
			// 
			// listBox2
			// 
			this.listBox2.Items.AddRange(new object[] {
														  "Xn-Xn-1",
														  "13*1/Math.Pow(2,0.5)*Math.Pow(0.5,Xn-Xn-1);",
														  "10*Math.Pow(0.5,Xn-Xn-1);"});
			this.listBox2.Location = new System.Drawing.Point(112, 24);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(232, 69);
			this.listBox2.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(112, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Funcion de Perturbacion f(Xn-Xn-1)";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(632, 446);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.simpleOpenGlControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Form1 f=new Form1();
			Application.Run(f);
		}

		private void simpleOpenGlControl1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.scene.Draw();
		}

		private void simpleOpenGlControl1_Resize(object sender, System.EventArgs e)
		{
			scene.Reshape(simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
		}

		private void scene_redraw(object sender, EventArgs e)
		{
			this.Refresh();
		}

		private void simpleOpenGlControl1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(!DesignMode)
			{
				scene.ProcessInput(e.KeyValue);
//				switch(e.KeyValue)
//				{
//					case (int)Keys.M:case (int)Keys.N:
//						statusBar1.Panels[1].Text="distancia: "+scene.cz  +"objetivo en :"+(scene.cz-30);
//						break;
//				}
				base.OnKeyDown(e);
				this.Refresh();
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Cursor=Cursors.WaitCursor;
			int x=(int)listBox1.SelectedItem;
			((MontanaFractal)scene.element).lev=x;
			((MontanaFractal)scene.element).fper=listBox2.SelectedIndex+1;
			((MontanaFractal)scene.element).Recompile();
			
			
			this.Refresh();
			this.Cursor=Cursors.Default;
		}

		

		

		
		
	}

