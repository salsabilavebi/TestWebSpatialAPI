using APIplaces.EFCore;

namespace APIplaces.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;

        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }

        public List<PlacesModel> GetPlaces()
        {
            List<PlacesModel> response = new List<PlacesModel>();
            var dataList = _context.Places.ToList();
            dataList.ForEach(row => response.Add(new PlacesModel()
            {
                Id = row.Id,
                OwnerName = row.OwnerName,
                placename = row.placename,
                address = row.address,
                placetype = row.placetype,  
                date = row.date

            }));
            return response;
        }

        public PlacesModel GetPlaceByid(int id)
        {
            PlacesModel response = new PlacesModel();
            var row = _context.Places.Where(d=>d.Id.Equals(id)).FirstOrDefault();
            return new PlacesModel()
            {
                OwnerName = row.OwnerName,
                placename = row.placename,
                address = row.address,
                placetype = row.placetype,
                date = row.date

            };
            
        }

        public void SavePlace(PlacesModel placeModel) 
        {
            Place dbTable = new Place();
            if(placeModel.Id > 0)
            {
                // Put 

                dbTable = _context.Places.Where(d => d.Id.Equals(placeModel.Id)).FirstOrDefault();
                if(dbTable != null)
                {
                    dbTable.OwnerName = placeModel.OwnerName;
                    dbTable.placename = placeModel.placename;
                    dbTable.address = placeModel.address;
                    dbTable.placetype = placeModel.placetype;
                    dbTable.date = placeModel.date;

                }


            }
            else
            {
                //POST
                
                dbTable.OwnerName = placeModel.OwnerName;
                dbTable.placename = placeModel.placename;
                dbTable.address = placeModel.address;
                dbTable.placetype = placeModel.placetype;
                dbTable.date = placeModel.date;
                _context.Places.Add(dbTable);
            }
            _context.SaveChanges();
        }

        public void DeletePlace(int id)
        {
            var place = _context.Places.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if(place != null)
            {
                _context.Places.Remove(place);  
                _context.SaveChanges();
            }
        }
    }
}
