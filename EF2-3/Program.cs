using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EFRecipesContext())
            {
                //add an artist with two albums
                var artist = new Artist { FirstName = "Alan", LastName = "Jackson" };
                var album1 = new Album { AlbumName = "Drive" };
                var album2 = new Album { AlbumName = "Live at Texas Stadium" };
                artist.Albums.Add(album1);
                artist.Albums.Add(album2);
                context.Artists.Add(artist);

                //add an album or two artist
                var artist1 = new Artist { FirstName = "Tobby", LastName = "Keith" };
                var artist2 = new Artist { FirstName = "Merle", LastName = "Haggard" };
                var album = new Album { AlbumName = "Honkytonk University" };
                //测试发现下面两行代码执行，专辑被插入但是作者没有被插入数据库
                //artist1.Albums.Add(album);
                //artist2.Albums.Add(album);

                //做出以下更改
                album.Artists.Add(artist1);
                album.Artists.Add(artist2);
                context.Albums.Add(album);

                context.SaveChanges();
            }

            using (var context = new EFRecipesContext())
            {
                Console.WriteLine("Artists and their albums...");
                var artists = context.Artists;
                foreach (var artist in artists)
                {
                    Console.WriteLine("{0} {1}",artist.FirstName,artist.LastName);
                    foreach (var album in artist.Albums)
                    {
                        Console.WriteLine("\t{0}",album.AlbumName);
                    }
                }

                Console.WriteLine("\nAlbums and their artist...");
                var albums = context.Albums;
                foreach (var album in albums)
                {
                    Console.WriteLine("{0}", album.AlbumName);
                    foreach (var artist in album.Artists)
                    {
                        Console.WriteLine("\t{0} {1}",artist.FirstName,artist.LastName);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
