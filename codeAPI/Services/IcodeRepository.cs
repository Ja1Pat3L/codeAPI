using System.Collections.Generic;
using System.Threading.Tasks;
using codeAPI.DTOs;
using codeLibrary.Models;

namespace codeAPI.Services
{
    public interface IcodeRepository
    {
        Task<bool> ClientExists(int client_id);
        Task<bool>TutorialExists(int id);
        Task<IEnumerable<Client>> GetClientTutorials();
        Task<Client> GetClientById(int id);
        Task<IEnumerable<Tutorial>> GetTutorialInfo();
        Task<Client> GetTutorialForClient(int client_id, int tutorial_id);
        Task<Tutorial> GetTutorialById(int client_id);
        Task<IEnumerable<Client>> GetTutorialsforClient(int client_id, Tutorial tutorial);
        Task AddTutorialsForClient(int client_id, Tutorial tutorial);
        void AddTutorial(Tutorial tutorial);
        void AddClient(Client client);
        void DeleteTutorial(Tutorial tutorial);
        void DeleteClient(Client client);

        void AddTutorialComment(TutorialComment tutorialcomment);

        Task <IEnumerable<TutorialComment>> GetTutorialComments(int tutorial_id);

        Task<TutorialComment>GetTutorialCommentsForClient(int client_id,int tutorial_id);

        void DeleteTutorialComment(TutorialComment tutorialcomment);

        Task <IEnumerable<ClientTutorial>> GetClientTutorials(int client_id);

        void AddClientTutorial(ClientTutorial clienttutorial);

        public Task<ClientTutorial> GetClientTutorial(int client_id,int tutorial_id);

        void DeleteClientTutorial(ClientTutorial clienttutorial);
        Task<bool> Save();
      
    }
}
