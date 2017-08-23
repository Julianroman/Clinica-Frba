using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class Auth
    {
        private String username;
        private String password;
        private Double intentosFallidos;
        private Boolean loggedIn;

        public Auth(String username, String password) 
        {
            this.username = username;
            this.password = password;
        }

        public Boolean login(string usernameX, string passwordX)
        {
            return this.loggedIn = (usernameX == username && passwordX == password);
        }




        //////////////////////
        // Setters & Getters//
        //////////////////////

        public String getUsername() { return username; }
        public String getPassword() { return password; }
        public Double getIntentosFallidos() { return intentosFallidos; }
        public Boolean isLogged() { return loggedIn; }

        


    }
}
