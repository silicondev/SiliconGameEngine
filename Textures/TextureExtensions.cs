﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SiliconGameEngine.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiliconGameEngine.Textures
{
    public static class TextureExtensions
    {
        public static List<Texture2D> GetSprites(this Texture2D sheet, GraphicsDevice device, int s)
        {
            List<Texture2D> lst = new List<Texture2D>();

            int texWidth = sheet.Width;
            int texHeight = sheet.Height;

            int sectX = (texWidth / s).Floor();
            int sectY = (texHeight / s).Floor();

            Color[] original = new Color[texWidth * texHeight];
            sheet.GetData(original);

            var sqr = s * s;

            for (int y = 0; y < sectY; y++)
            {
                for (int x = 0; x < sectX; x++)
                {
                    var tex = new Texture2D(device, s, s);
                    Color[] data = new Color[sqr];

                    for (int py = 0; py < s; py++)
                    {
                        for (int px = 0; px < s; px++)
                        {
                            int index = px + py * s;
                            data[index] = original[(x + px) + (y + py) * texWidth];
                        }
                    }

                    tex.SetData(data);
                    lst.Add(tex);
                }
            }

            return lst;
        }
    }
}