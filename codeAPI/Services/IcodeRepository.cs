using System.Collections.Generic;
using System.Threading.Tasks;
using codeAPI.DTOs;
using codeLibrary.Models;

namespace codeAPI.Services
{
    public interface IcodeRepository
    {

        #region CLIENT METHODS
        Task<bool> ClientExists(int client_id);
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientById(int id);
        void AddClient(Client client);
        void DeleteClient(Client client);
        #endregion

        #region TUTORIAL METHODS
        Task<bool> TutorialExists(int id);

        Task<IEnumerable<Tutorial>> GetTutorialInfo();
        Task<Tutorial> GetTutorialById(int client_id);
        void AddTutorial(Tutorial tutorial);
        void DeleteTutorial(Tutorial tutorial);
        #endregion

        #region ClLIENT TUTORIAL METHODS
        void AddTutorialComment(TutorialComment tutorialcomment);

        Task<IEnumerable<TutorialComment>> GetTutorialComments(int tutorial_id);

        Task<TutorialComment> GetTutorialCommentsForClient(int client_id, int tutorial_id);

        void DeleteTutorialComment(TutorialComment tutorialcomment);
        #endregion

        #region TUTORIAL COMMENT METHODS

        Task<IEnumerable<ClientTutorial>> GetClientTutorials(int client_id);

        void AddClientTutorial(ClientTutorial clienttutorial);

        public Task<ClientTutorial> GetClientTutorial(int client_id, int tutorial_id);

        void DeleteClientTutorial(ClientTutorial clienttutorial);
        #endregion

        #region SAVE METHOD
        Task<bool> Save();
        #endregion
    }





}
