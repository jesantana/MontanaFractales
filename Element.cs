using System;
using Tao.OpenGl;


	public abstract class Element:IElement
	{
		public int idVisualizar;
		protected float width;
		private double rx; // angulo de rotacion sobre el eje x
		private double ry; // angulo de rotacion sobre el eje y
		private double rz; // angulo de rotacion sobre el eje z
		

		public Element(float width)
		{
			this.width = width;
			idVisualizar = Gl.glGenLists(1);
		}

		public virtual int Id
		{
			get{return idVisualizar;}
		}

		public virtual string GetObjName(int id)
		{
			int i=idVisualizar;
			return "";
		}
		
		

		public Element() : this(1.0f){}
		
		public virtual void Draw()
		{
			if(idVisualizar != 0)
			{
				Gl.glPushMatrix();
				this.Rota();
				Gl.glCallList(idVisualizar);
				Gl.glPopMatrix();
			}
		}

		public virtual void Rota()
		{
			
			Gl.glTranslated(this.PuntoRotacion.x, this.PuntoRotacion.y, this.PuntoRotacion.z);
			Gl.glRotated(rx, 1, 0, 0);
			Gl.glRotated(ry, 0, 1, 0);
			Gl.glRotated(rz, 0, 0, 1);
			Gl.glTranslated(-this.PuntoRotacion.x, -this.PuntoRotacion.y, -this.PuntoRotacion.z);
		}

		public virtual void Rota(double angle,int x,int y,int z)
		{
			Gl.glTranslated(this.PuntoRotacion.x, this.PuntoRotacion.y, this.PuntoRotacion.z);
			Gl.glRotated(angle, x, y, z);
			Gl.glTranslated(-this.PuntoRotacion.x, -this.PuntoRotacion.y, -this.PuntoRotacion.z);


		}

		public void RotateX(int direction)
		{
			rx += Math.Sign(direction)*5;
		}


		public void RotateY(int direction)
		{
			ry += Math.Sign(direction)*5;
		}


		public void RotateZ(int direction)
		{
			rz += Math.Sign(direction)*5;
		}

        public float Width
        {
            get { return width; }
            set
            {
                width = value;
                Recompile();
            }
        }

		public abstract void Recompile();
		public abstract Point3D PuntoRotacion{
		get;
		}

		public virtual void Destroy()
		{
			Gl.glDeleteLists(idVisualizar, 1);
		}
	}


		
