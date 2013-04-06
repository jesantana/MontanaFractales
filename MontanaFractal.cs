using System;
using System.Collections;
using Tao.OpenGl;
using Tao.Glut;
using System.Windows.Forms;


public class MontanaFractal:Element
{
	Stack pilaTriang;
	double distab,distac,distbc;
	double maxdist;
	public int lev;
	public int triangleCount;
	public int inSeed;
	public int fper;
	

	public MontanaFractal(int n,int funcionPert)
	{
		pilaTriang=new Stack();
		//pilaTriang.Push(new Triangulo(new Point3D(-3,0,-20),new Point3D(0,0,-20),new Point3D(-1.5,1.5,-20)));
		lev=n;
		fper=funcionPert;
		int count=0;
		for(int i=0;i<lev;i++)
		{
		count+=(int)Math.Pow(4,i);
		}
		inSeed=0;
		this.Recompile();
	}

	public void GeneraMontana()
	{
		triangleCount=0;
		Point3D a=new Point3D(-2.5,0,-3);
		Point3D b=new Point3D(2.5,0,-3);
		Point3D c=new Point3D(2.5,0,-8);
		Point3D d=new Point3D(-2.5,0,-8);

		Triangulo t1=new Triangulo(a,c,d);
		Triangulo t=new Triangulo(a,b,c);
		distab=Point3D.Distancia(a,b);
		distbc=Point3D.Distancia(b,c);
		distac=Point3D.Distancia(a,c);
		maxdist=Math.Max(distab,distbc);
		maxdist=Math.Max(maxdist,distac);
		
		
		
		GeneraMontana(t,1);
		GeneraMontana(t1,1);

		
	}
	
	private void GeneraMontana(Triangulo t,int n)
	{
		if(n<lev)
		{
			PintaTriangulo(t);
			Point3D ab,bc,ac;
			ab=Point3D.PuntoMedio(t.a,t.b);
			bc=Point3D.PuntoMedio(t.b,t.c);
			ac=Point3D.PuntoMedio(t.a,t.c);

			double seedab=GetSeed(ab);
			double seedbc=GetSeed(bc);
			double seedac=GetSeed(ac);
			

			ab.y+=P(n,Math.Abs(Point3D.Distancia(t.a,t.b)))*(new Random((int)seedab).NextDouble())*0.5;
			bc.y+=P(n,Math.Abs(Point3D.Distancia(t.b,t.c)))*(new Random((int)seedbc).NextDouble())*0.5;
			ac.y+=P(n,Math.Abs(Point3D.Distancia(t.a,t.c)))*(new Random((int)seedac).NextDouble())*0.5;

			
			PintaTriangulo(new Triangulo(t.a,ab,t.b));
			PintaTriangulo(new Triangulo(t.b,bc,t.c));
			PintaTriangulo(new Triangulo(t.a,ac,t.c));
			
			Triangulo[] nuevoTri=new Triangulo[4];
			   			
			
			
			nuevoTri[0]=new Triangulo(t.a,ab,ac);
			nuevoTri[1]=new Triangulo(t.b,bc,ab);
			nuevoTri[2]=new Triangulo(t.c,ac,bc);
			nuevoTri[3]=new Triangulo(bc,ac,ab);

			for(int i=0;i<nuevoTri.Length;i++)
			{
				GeneraMontana(nuevoTri[i],n+1);
			}
		}
		else
		{
			PintaTriangulo(t);
		}
	}

	private double GetSeed(Point3D p)
	{
	return 123456*p.x*p.y+234564*p.y*p.z+643322*p.x*p.z+inSeed;
	}

	private double P(int n,double initialDist)
	{
		switch(fper){
			case 0:return initialDist;
			case 2:return 13*1/Math.Pow(2,0.5)*Math.Pow(0.5,n);
			case 3:return 10*Math.Pow(0.5,n);
			default:return initialDist;
		
		}
		//1.3*Math.Log(0.6+new Random().NextDouble()*0.3+initialDist,2); 
	}

	public override void Recompile()
	{
		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
		Gl.glPushMatrix();
		Gl.glDisable(Gl.GL_CULL_FACE);
		Gl.glColor3d(0.7,0.0,0.0);
		Gl.glTranslated(0,-2,0);
		

		this.Rota(250,0,1,0);
		Gl.glBegin(Gl.GL_TRIANGLES);
		GeneraMontana();
		Gl.glEnd();
		Gl.glEnable(Gl.GL_CULL_FACE);
		Gl.glPopMatrix();
		Gl.glEndList();

		
	}

	public override Point3D PuntoRotacion
	{
		get
		{
			return new Point3D (0,0.75,-5.5);
		}
	}

	public void GeneraColor(Point3D p)
	{
		if(p.y > 0.4*maxdist) 
		{
			Gl.glColor3d(1.0, 1.0, 1.0);
		} 
		else if(p.y <0.025*maxdist) 
		{
			Gl.glColor3d(0.85, 0.88, 0.53);
		} 
		else if(p.y < 0.05*maxdist) 
		{
			Gl.glColor3d(0.0, 0.4, 0.0);
		} 
		else if(p.y< 0.15*maxdist) 
		{
			Gl.glColor3d(0.0,
				0.4 - 0.2 / (2.0 - 10.0 *(p.y*maxdist - 0.05)),
				0.0);
		} 
		else 
		{
			Gl.glColor3d(0.68, 0.45, 0.26);
		}
	}

	public void PintaTriangulo(Triangulo t)
	{
		triangleCount++;
		Point3D normal=t.ComputeNormal();
		GeneraColor(t.a);	
		Gl.glNormal3d(normal.x,normal.y,normal.z);
		Gl.glVertex3d(t.a.x,t.a.y,t.a.z);
		
		GeneraColor(t.b);	
		Gl.glNormal3d(normal.x,normal.y,normal.z);
		Gl.glVertex3d(t.b.x,t.b.y,t.b.z);
		
		GeneraColor(t.c);	
		Gl.glNormal3d(normal.x,normal.y,normal.z);
		Gl.glVertex3d(t.c.x,t.c.y,t.c.z);
	}
	
}

