using System;
using Tao.OpenGl;
using System.Windows.Forms;


	/// <summary>
	/// Summary description for Scene.
	/// </summary>
	public class Scene
	{
		#region fields

		public IElement element;
        private float[] color;
		public double[] activeRotateVector;
		private bool bomon,ambon;
		public string nombre;
		public Camara cam;
		public int cz;
		public bool first;

		#endregion

		public Scene()
		{
            color = new float[] { 1.0f, 0.0f, 0.0f };
			activeRotateVector = new double[3]{1, 0, 0};
			bomon=true;
			ambon=true;
			cam=new Camara();
			cz=0;
			first=true;
			
			Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);	
			//Otros.LoadTexture();
			SituaBomb();
			SituaLuzAmb();
		}


 		#region methods

		

		public void ProcessInput(int key)
		{
			switch(key)
			{
				case (int)Keys.I: // increment
					Rotate(1);
					break;
				case (int)Keys.D: // decrement
					Rotate(-1);
					break;
				case (int)Keys.X:
					activeRotateVector = new double[3]{1, 0, 0};
//					if(rotateVectorChanged != null)
//						rotateVectorChanged(this, null);
					break;
				case (int)Keys.Y:
					activeRotateVector = new double[3]{0, 1, 0};
//					if(rotateVectorChanged != null)
//						rotateVectorChanged(this, null);
					break;
				case (int)Keys.Z:
					activeRotateVector = new double[3]{0, 0, 1};
//					if(rotateVectorChanged != null)
//						rotateVectorChanged(this, null);
					break;
				case (int)Keys.M:
					cz-=2;
					cam.SetPos(new Point3D(0,0,cz),new Point3D(0,0,cz-20),0,1,0);
					break;
				case (int)Keys.N:
					cz+=2;
					cam.SetPos(new Point3D(0,0,cz),new Point3D(0,0,cz-20),0,1,0);
					break;
			}
		}

		private void Rotate(int direction)
		{
				if(activeRotateVector[0] == 1 && activeRotateVector[1] == 0 && activeRotateVector[2] == 0)
					element.RotateX(direction);
				else if(activeRotateVector[0] == 0 && activeRotateVector[1] == 1 && activeRotateVector[2] == 0)
					element.RotateY(direction);
				else if(activeRotateVector[0] == 0 && activeRotateVector[1] == 0 && activeRotateVector[2] == 1)
					element.RotateZ(direction);
				
		}

		


		public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glColor3fv(color);
					
			if(first)
			{
				Gl.glEnable(Gl.GL_LIGHTING);
				Gl.glEnable(Gl.GL_COLOR_MATERIAL);	
			
				SituaBomb();
				SituaLuzAmb();
				first=false;
			}

			EncenderBomb(this.BombiOn);
			EncenderLuzAmb(this.ambon);
			cam.SetPos(new Point3D(0,0,cz),new Point3D(0,0,cz-20),0,1,0);
			
			if(element!=null)
			
			element.Draw();
			
			
            Gl.glFlush();
		}

		#region Luces
		public void SituaLuzAmb()
		{
			Gl.glLightfv(Gl.GL_LIGHT1,Gl.GL_AMBIENT,new float[]{0.35f,0.35f,0.35f,1.0f});
			Gl.glLightfv(Gl.GL_LIGHT1,Gl.GL_DIFFUSE,new float[]{0.35f,0.35f,0.35f,1.0f});
			Gl.glLightfv(Gl.GL_LIGHT1,Gl.GL_SPECULAR,new float[]{0.1f,0.1f,0.1f,1.0f});		
		}

		public void SituaBomb()
		{
			Gl.glLightfv(Gl.GL_LIGHT0,Gl.GL_AMBIENT,new float[]{0.35f,0.35f,0.35f,1.0f});
			Gl.glLightfv(Gl.GL_LIGHT0,Gl.GL_DIFFUSE,new float[]{0.35f,0.35f,0.35f,1.0f});
			Gl.glLightfv(Gl.GL_LIGHT0,Gl.GL_SPECULAR,new float[]{0.1f,0.1f,0.1f,1.0f});
			
			Gl.glLightfv(Gl.GL_LIGHT0,Gl.GL_POSITION,new float[]{0f,0f,0f,1.0f});
			Gl.glLightf(Gl.GL_LIGHT0,Gl.GL_SPOT_CUTOFF,60);
			Gl.glLightfv(Gl.GL_LIGHT0,Gl.GL_SPOT_DIRECTION,new float[]{0f,0f,-1.0f});



//			Gl.glLightfv(Gl.GL_LIGHT2,Gl.GL_AMBIENT,new float[]{0.35f,0.35f,0.35f,1.0f});
//			Gl.glLightfv(Gl.GL_LIGHT2,Gl.GL_DIFFUSE,new float[]{0.35f,0.35f,0.35f,1.0f});
//			Gl.glLightfv(Gl.GL_LIGHT2,Gl.GL_SPECULAR,new float[]{0.1f,0.1f,0.1f,1.0f});
//			
//			Gl.glLightfv(Gl.GL_LIGHT2,Gl.GL_POSITION,new float[]{-10f,3f,-5.5f,1.0f});
//			Gl.glLightf(Gl.GL_LIGHT2,Gl.GL_SPOT_CUTOFF,60);
//			Gl.glLightfv(Gl.GL_LIGHT2,Gl.GL_SPOT_DIRECTION,new float[]{1.0f,0f,0f});
		
		}

				
		public void EncenderLuzAmb(bool on)
		{
			if(on)
			{
				
				Gl.glEnable(Gl.GL_LIGHT1);
			}
			else Gl.glDisable(Gl.GL_LIGHT1);
		}

		public void EncenderBomb(bool on)
		{
			if(on)
			{// si el ultimo elemento del arreglo es 1 la luz es puntual
				
				Gl.glEnable(Gl.GL_LIGHT0);
				
			}
			else {Gl.glDisable(Gl.GL_LIGHT0);
			
			}
		}
		#endregion
		
		#region Seleccion de Objetos
		public int[] StartPicking(int cursorX, int cursorY) 
		{
			int[] viewport = new int[4];
			int[] selectBuf = new int[512];

			Gl.glSelectBuffer(512, selectBuf);
			Gl.glRenderMode(Gl.GL_SELECT);

			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glPushMatrix();
			Gl.glLoadIdentity();

			Gl.glGetIntegerv(Gl.GL_VIEWPORT,viewport);
			Glu.gluPickMatrix(cursorX, viewport[3]-cursorY, 5, 5, viewport);
			Glu.gluPerspective(45.0, (double)viewport[2] / (double)viewport[3], 0.1, 1500);
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glInitNames();
			Gl.glPushName(0);
			return selectBuf;
		}

		/// <summary>
		/// Metodo que se utiliza para parar la seleccion.
		/// </summary>
		public int StopPicking()
		{
			int hits;
	
			// restoring the original projection matrix
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glPopMatrix();
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glFlush();
	
			// returning to normal rendering mode
			hits = Gl.glRenderMode(Gl.GL_RENDER);
	
			return hits;
		}

		/// <summary>
		/// Procesa cada hits
		/// </summary>
		public int ProcessHits(int hits, int[] buffer) 
		{
			int i;
			int[] ptr;
			int minz = Int32.MaxValue;
			int name = 0;

			ptr = buffer;
			for(i = 0; i < hits*4; i+=4) 
				if(ptr[i+1] < minz)
				{
					minz = ptr[i+1];
					name = ptr[i+3];
				}

			return name;
		}

		/// <summary>
		/// Dibuja los elementos para la seleccion.
		/// </summary>
		public void DrawElementsName()
		{
			//cada vez que se le ponga un nombre en la pila habra algo diferente en los hits
			element.Draw();
			
		}

		public bool SelectElement(int xp, int yp)
		{
			int[] selectBuf = StartPicking(xp, yp);			
			DrawElementsName();
			int hits = StopPicking();
			int id = ProcessHits(hits, selectBuf);
			if(id > 0)
			{
				
				nombre=element.GetObjName(id);
				if(nombre!="")return true;
				else return false;
			}
			return false;
		}
	
		#endregion

		#region Manipular Escena
		
		public void Redraw()
		{
			if (redraw != null)
				redraw(this, EventArgs.Empty);
		}

		public virtual void Reshape(int width, int height)
		{
			if (height == 0)
				height = 1;

			Gl.glViewport(0, 0, width, height);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Glu.gluPerspective(45.0, (double)width / (double)height, 0.1, 1500);
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glLoadIdentity();
		}

		public void Initialize()
		{
			Gl.glShadeModel(Gl.GL_SMOOTH);
			Gl.glClearColor(0.0f,0.0f,0.0f,0.0f);
			//Gl.glClearColor(0.0f, 0.5f, 0.5f, 0.0f);
			Gl.glClearDepth(1.0f);
			Gl.glEnable(Gl.GL_DEPTH_TEST);
			Gl.glEnable(Gl.GL_CULL_FACE);
			Gl.glCullFace(Gl.GL_BACK);
			Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
			Reshape(640, 480);
		}
		#endregion

		#endregion

		#region properties

		public bool BombiOn
		{
			get{return this.bomon;}
			set{bomon=value;}
		
		}

		public bool AmbiOn
		{
			get{return this.ambon;}
			set{ambon=value;}
		
		}


		public float[] Color 
        {
            get { return color; }
            set
            {
                color = value;
                Redraw();
            }
        }
		#endregion

		#region eventos

		/// <summary>
		/// evento para mandar a dibujar.
		/// </summary>
		public event EventHandler redraw;

		#endregion eventos
	}

	

