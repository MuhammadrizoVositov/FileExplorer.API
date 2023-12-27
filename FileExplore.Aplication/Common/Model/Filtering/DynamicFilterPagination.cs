using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplore.Aplication.Common.Model.Filtering
{
    public class DynamicFilterPagination
    {
        private readonly FilterPagination _filterPaginationOption;
        private readonly uint _dynamizPagesize;
        private  uint _dynamizPageSizeRemainder;

        public DynamicFilterPagination(FilterPagination pagination , uint callasCount)
        {
            if(pagination == null) throw new ArgumentNullException("Calls count must be greater than zero",nameof(callasCount));
            _filterPaginationOption = _filterPaginationOption;
            (_dynamizPagesize, _dynamizPageSizeRemainder) = _filterPaginationOption.PageSize < callasCount
                ? (_filterPaginationOption.PageSize, default)
                : (_filterPaginationOption.PageSize / callasCount, _filterPaginationOption.PageSize % callasCount);
        }
        public uint PageToken
        {
            get => _filterPaginationOption.PageToken;
            set=> _filterPaginationOption.PageToken = value;
        }
        public uint PageSize
        {
            get
            {
                if(_filterPaginationOption.PageSize==default) return default;
                var currentDynamicPageSize= _dynamizPagesize;
                if(_dynamizPageSizeRemainder>0)
                {
                    currentDynamicPageSize++;
                    _dynamizPageSizeRemainder--;
                }
                _filterPaginationOption.PageSize -= currentDynamicPageSize;
                return currentDynamicPageSize;
            }
            set=> _filterPaginationOption.PageSize = value;
        }
    }
           
    }
    

