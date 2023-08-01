using System;
using System.Linq;
using System.Text;
using FsyaFignya.DataBase;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;

namespace FsyaFignya.Adapter
{
    public class BaseRepository
    {
        protected readonly Context _context;
        protected readonly IMapper _mapper;

        public BaseRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}