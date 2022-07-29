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
        #region INSTANCE FOR DATABASE CONTEXT (DBcontext)
        private codedBContext DBContext;
        #endregion

        #region CONSTRUCTOR
        public codeRepository(codedBContext dBContext)
        {
            this.DBContext = dBContext;
        }
        #endregion

        #region CLIENT METHODS
        public async Task<bool> ClientExists(int client_id)
        {
            return await DBContext.Clients.AnyAsync<Client>(c=>c.ClientId==client_id);
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            var result = DBContext.Clients.OrderBy(c => c.ClientName);
            return await result.ToListAsync();
        }

        public Task<Client> GetClientById(int id)
        {
            IQueryable<Client> result;
            //  IQueryable<Tutorial> result;
            result = DBContext.Clients.Where(t => t.ClientId == id);
            return result.FirstOrDefaultAsync();
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

        #endregion

        #region TUTORIAL METHODS
        public async Task<IEnumerable<Tutorial>> GetTutorialInfo()
        {
            var result = DBContext.Tutorials.OrderBy(c => c.TutorialName);
            return await result.ToListAsync();

        }

        public async Task<bool> TutorialExists(int id)
        {
            return await DBContext.Tutorials.AnyAsync<Tutorial>(c => c.TutorialId == id);
        }

        public Task<Tutorial> GetTutorialById(int client_id)
        {
            IQueryable<Tutorial> result;
            //  IQueryable<Tutorial> result;
            result = DBContext.Tutorials.Where(t => t.TutorialId == client_id);
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

        public void DeleteTutorial(Tutorial tutorial)
        {

            DBContext.Tutorials.Remove(tutorial);
        }
        #endregion

        #region SAVE METHOD
        public async Task<bool> Save()
        {
            var changes = await DBContext.SaveChangesAsync();
            return changes > 0;
        }
        #endregion

        #region TUTORIAL COMMENT METHODS
        public async Task<IEnumerable<TutorialComment>> GetTutorialComments(int tutorial_id)
        {
            IQueryable<TutorialComment> result;
            result = DBContext.TutorialComments.Where(t => t.TutorialId == tutorial_id);
            return await result.ToListAsync();
        }
   
        public async Task<TutorialComment> GetTutorialCommentsForClient(int client_id,int tutorial_id)
        {
            IQueryable<TutorialComment> result;
            result = DBContext.TutorialComments.Where(t => t.TutorialId == tutorial_id &&  t.ClientId == client_id) ;
            return await result.FirstOrDefaultAsync();
        }



        public void DeleteTutorialComment(TutorialComment tutorialcomment)
        {
            DBContext.TutorialComments.Remove(tutorialcomment);
        }
        #endregion

        #region CLIENT TUTORIAL METHODS
        public async Task<IEnumerable<ClientTutorial>> GetClientTutorials(int client_id)
        {
            IQueryable<ClientTutorial> result;
            result = DBContext.ClientTutorials.Where(t => t.ClientId == client_id);
            return await result.ToListAsync();
                
        }

        public async Task<ClientTutorial> GetClientTutorial(int client_id,int tutorial_id)
        {
            IQueryable<ClientTutorial> result;
            result = DBContext.ClientTutorials.Where( t => t.ClientId==client_id && t.TutorialId == tutorial_id );
            return await result.FirstOrDefaultAsync();

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
        #endregion
    }
}