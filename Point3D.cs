using System;

public struct Point3D
{
	public double x, y, z;

	public Point3D(double x, double y, double z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}
		

	public double[] Coords
	{
		get{ return new double[]{x, y, z}; }
	}

	public double ValorEscalar
	{
		get{return Math.Sqrt(Math.Pow(x,2)+Math.Pow(y,2)+Math.Pow(z,2));}
	}

	
	public Point3D Normalizar()
	{
		double valesc=ValorEscalar;
		Point3D ret;
		ret.x=x/valesc;
		ret.y=y/valesc;
		ret.z=z/valesc;
		return ret;
	}

	public static double Distancia(Point3D p1,Point3D p2)
	{
		return Math.Sqrt(Math.Pow(p1.x-p2.x,2)+Math.Pow(p1.y-p2.y,2)+Math.Pow(p1.z-p2.z,2));
	}

	public static Point3D PuntoMedio(Point3D p1,Point3D p2)
	{
		return new Point3D((p1.x+p2.x)/2,(p1.y+p2.y)/2,(p1.z+p2.z)/2);
	}

	public static Point3D operator -(Point3D p1,Point3D p2)
	{
		return new Point3D(p1.x-p2.x,p1.y-p2.y,p1.z-p1.z);
	} 
}
