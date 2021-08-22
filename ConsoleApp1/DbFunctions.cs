using SpeechToText;
using Microsoft.EntityFrameworkCore;
using SpeechToText.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToText
{
    public class DbFunctions
    {
        public FilesDBContext FilesDBContext;

        public DbFunctions(FilesDBContext FilesDBContext)
        {
            this.FilesDBContext = FilesDBContext;
        }

        public async Task postFile(File file)
        {
            await FilesDBContext.Files.AddAsync(file);
            await FilesDBContext.SaveChangesAsync();
        }
        public async Task<File> getFile(int id)
        {
            return await FilesDBContext.Files.Where(file => file.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}
