using System;

public class Triangulo
{
	public Point3D a,b,c,up;
		
	public Triangulo(Point3D a1,Point3D b1,Point3D c1)
	{
		this.a=a1;
		this.b=b1;
		this.c=c1;
	}

	public static Point3D ProductoCruzado(Point3D a1,Point3D b1)
	{
		return new Point3D(a1.y *b1.z-b1.y * a1.z,
			a1.z*b1.x - b1.z *a1.x,
			a1.x *b1.y - b1.x *a1.y);
	}

	public static double ProductoPuntual(Point3D a1,Point3D b1)
	{
		return a1.x*b1.x+a1.y*b1.y+a1.z*b1.z;
		
	}

	public Point3D ComputeNormal()
	{
		Point3D result;
		result=ProductoCruzado(this.b-this.a,this.a-this.c);
		result=result.Normalizar();
		if(ProductoPuntual(result,up.Normalizar())<0)
		{
			result.x=-result.x;
			result.y=-result.y;
			result.z=-result.z;
		}
		return result;
	}
}

