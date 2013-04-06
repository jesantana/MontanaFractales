using System;
using Tao.OpenGl;
using System.Drawing.Imaging;
using System.Drawing;


public class Text:Element
	{
			
	

	public Text()
	{
		Otros.LoadTexture();
		this.Recompile();
		
	}
	
	public override void Recompile()
	{
		Gl.glNewList(idVisualizar,Gl.GL_COMPILE);
		Gl.glPushMatrix();
		Gl.glColor3d(0.2,0.34,0.44);
		Gl.glDisable(Gl.GL_CULL_FACE);
		Gl.glBindTexture(Gl.GL_TEXTURE_2D,Otros.texture[0]);
		Gl.glBegin(Gl.GL_POLYGON);
			Gl.glTexCoord2f(0.0f,0.0f);Gl.glVertex3d(-4,2,-20);
			Gl.glTexCoord2f(1.0f,0.0f);Gl.glVertex3d(4,2,-20);
			Gl.glTexCoord2f(1.0f, 1.0f);Gl.glVertex3d(4,-2,-20);
			Gl.glTexCoord2f(0.0f,1.0f);Gl.glVertex3d(-4,-2,-20);
		Gl.glEnd();
		Gl.glEnable(Gl.GL_CULL_FACE);
		Gl.glPopMatrix();
		Gl.glEndList();
	}

	public override Point3D PuntoRotacion
	{
		get
		{
			return new Point3D (0,0,-20);
		}
	}

	public static Bitmap LoadBitmapFromFile(string filename, out BitmapData bitmapData)
	{
		Bitmap bitmap = null;												
		Rectangle rectangle;											
		bitmapData = null;

		bitmap = new System.Drawing.Bitmap(filename);											
		bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);						
		rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
		bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			
		return bitmap;
	}

}

