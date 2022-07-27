using codeAPI.DTOs;
using codeLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codeAPI.Services
{
    public class codeRepository : IcodeRepository

       
    {

        private codedBContext DBContext;

        public codeRepository(codedBContext dBContext)
        {
            this.DBContext = dBContext;
        }
        public async Task<bool> ClientExists(int client_id)
        {
            return await DBContext.Clients.AnyAsync<Client>(c=>c.ClientId==client_id);
        }
        public async Task<IEnumerable<Client>> GetClientTutorials()
        {
            var result = DBContext.Clients.OrderBy(c => c.ClientName);
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<Tutorial>> GetTutorialInfo()
        {
            var result = DBContext.Tutorials.OrderBy(c => c.TutorialName);
            return await result.ToListAsync();

        }
      
        public async Task<IEnumerable<Client>> GetTutorialsforClient(int client_id, Tutorial tutorial)
        {
            IQueryable<Client> result;

            result = DBContext.Clients.Include(t => t.Tutorial == tutorial).Where(c => c.ClientId == client_id);
            return await result.ToListAsync();

        }
        public Task AddTutorialsForClient(int client_id, Tutorial tutorial)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTutorial(Tutorial tutorial)
        {

            DBContext.Tutorials.Remove(tutorial);
        }

      

        public async Task<bool> Save()
        {
            var changes = await DBContext.SaveChangesAsync();
            return changes > 0;
        }

        public Task<Tutorial> GetTutorialById(int client_id)
        {
            IQueryable<Tutorial> result;
            //  IQueryable<Tutorial> result;
            result = DBContext.Tutorials.Where(t => t.TutorialId == client_id);
            return result.FirstOrDefaultAsync();
        }

        public async Task<bool> TutorialExists(int id)
        {
            return await DBContext.Tutorials.AnyAsync<Tutorial>(c => c.TutorialId== id);
        }

        public async Task<Client> GetTutorialForClient(int client_id, int tutorial_id)
        {
            IQueryable<Client> result = DBContext.Clients.Where(p => p.ClientId == client_id && p.TutorialId == tutorial_id);
            return await result.FirstOrDefaultAsync();
        }

        public void DeleteTutorialForClient(Client client)
        {
            DBContext.Clients.Remove(client);
        }

        public Task<Client> GetClientById(int id)
        {
            IQueryable<Client> result;
            //  IQueryable<Tutorial> result;
            result = DBContext.Clients.Where(t => t.ClientId == id);
            return result.FirstOrDefaultAsync();
        }

        public void AddTutorial(Tutorial tutorial)
        {

            //  IQueryable<Tutorial> result;
            try
            {

                DBContext.Tutorials.Add(tutorial);
            }
            catch
            {

            }


        }

        public void AddClient(Client client)
        {
            try
            {

                DBContext.Clients.Add(client);
            }
            catch
            {

            }
        }

        public void DeleteClient(Client client)
        {
            DBContext.Clients.Remove(client);
        }

        public void AddTutorialComment(TutorialComment tutorialcomment)
        {
            try
            {

                DBContext.TutorialComments.Add(tutorialcomment);
            }
            catch
            {

            }


        }

        public async Task<IEnumerable<TutorialComment>> GetTutorialComments(int tutorial_id)
        {
            IQueryable<TutorialComment> result;
            result = DBContext.TutorialComments.Where(t => t.TutorialId == tutorial_id);
            return await result.ToListAsync();
        }
    

      
        public void DeleteTutorialComment(TutorialComment tutorialcomment)
        {
            DBContext.TutorialComments.Remove(tutorialcomment);
        }

        public async Task<IEnumerable<ClientTutorial>> GetClientTutorials(int client_id)
        {
            IQueryable<ClientTutorial> result;
            result = DBContext.ClientTutorials.Where(t => t.ClientId == client_id);
            return await result.ToListAsync();
                
        }

        public void AddClientTutorial(ClientTutorial clienttutorial)
        {
            try
            {

                DBContext.ClientTutorials.Add(clienttutorial);
            }
            catch
            {

            }


        }

        public void DeleteClientTutorial(ClientTutorial clientTutorial)
        {
            DBContext.ClientTutorials.Remove(clientTutorial);
        }



    }
}