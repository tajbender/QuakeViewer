using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IDSoftware;

namespace QuakeViewer
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      using (PakStreamReader psr = new PakStreamReader(@"C:\QUAKE_SW\ID1\PAK0.PAK")) {
        // Show all contained PakEntry-Names in ListView
        foreach (PakEntry pe in psr.PakEntries)
          this.lbxEntries.Items.Add(pe.ContentName);

        //// Save contained sound-File in WAV-Format to disk
        //psr.SavePakEntryContent(@"sound/weapons/guncock.wav", @"C:\QuakeTestSound.wav");

        // Load contained BSP-File
        BspHeader bsp = new BspHeader(psr, @"maps/start.bsp");
        ////this.bsp = new BspHeader(psr, @"maps/e1m3.bsp");
        ////this.bsp = new BspHeader(psr, @"maps/e1m2.bsp"); // OutOfMemoryException!
        //foreach (BspMipMapInfo bmi in bsp.MipHeader.MipMapInfo)
        //  this.lbxEntries.Items.Add(bmi.Name);


        //// Load lump picture
        //LumpPicture lump = new LumpPicture(psr, @"gfx/complete.lmp"); //"gfx/sp_menu.lmp"
        //this.pictureBox1.Image = this.lump.Bitmap;

        // Load alias model
        ModelHeader model = new ModelHeader(psr, @"progs/lavaball.mdl");
        this.pictureBox1.Image = model.Skin.Bitmap[0];

      }
    }

    private void lbxEntries_SelectedIndexChanged(object sender, EventArgs e) {
      //int idx = lbxEntries.SelectedIndex;
      //this.pictureBox1.Image = this.bsp.MipHeader.MipMapInfo[idx].MipMapTexture[0].GetBitmap(this.pakPal);

    }
  }
}