using Newtonsoft.Json;

namespace DemoSessionAsp.Infrastructure
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            ArgumentNullException.ThrowIfNull(httpContextAccessor.HttpContext);
            _session = httpContextAccessor.HttpContext.Session;
        }

        public string? Courriel
        {
            get { return _session.GetString(nameof(Courriel)); }
            set 
            {
                if (value is null)
                    return;

                _session.SetString(nameof(Courriel), value); 
            }
        }

        public List<string> Panier
        {
            get 
            {
                List<string> panier;
                if(!_session.Keys.Contains(nameof(Panier)))
                {
                    panier = new List<string>();
                    _session.SetString(nameof(Panier), JsonConvert.SerializeObject(panier));
                }
                else
                {
                    string json = _session.GetString(nameof(Panier))!;
                    panier = JsonConvert.DeserializeObject<List<string>>(json)!;
                }
                return panier;  
            }

            private set
            {
                _session.SetString(nameof(Panier), JsonConvert.SerializeObject(value));
            }
        }

        public void AddIntoBasket(string value)
        {
            List<string> panier = Panier;
            panier.Add(value);
            Panier = panier;
        }

    }
}
