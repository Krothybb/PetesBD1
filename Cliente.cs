using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetesBD
{
    class Cliente
    {
        //Datos de cliente
        private string nombre;
        private string apellido;
        private string domicilio;
        private string cp;
        private string pueblo;

        public string elnombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public string elapellido
        {
            get
            {
                return this.elapellido;
            }
            set
            {
                this.elapellido = value;
            }
        }
        public string eldomicilio
        {
            get
            {
                return this.eldomicilio;
            }
            set
            {
                this.eldomicilio = value;
            }
        }
        public string elcp
        {
            get
            {
                return this.elcp;
            }
            set
            {
                this.elcp = value;
            }
        }
        public string elpueblo
        {
            get
            {
                return this.elpueblo;
            }
            set
            {
                this.elpueblo = value;
            }
        }

    }
    class renta
    {
        private int flat;
        private int lote;
        private float costo;
        private String zona;
        private double numerolote;

        public int elflat
        {
            get
            {
                return this.flat;
            }
            set
            {
                this.flat = value;
            }
        }
        public int ellote
        {
            get
            {
                return this.lote;
            }
            set
            {
                this.lote = value;
            }
        }
        public double elcosto
        {
            get
            {
                return this.elcosto;
            }
            set
            {
                this.elcosto = value;
            }
        }
        public String lazona
        {
            get
            {
                return this.lazona;
            }
            set
            {
                this.lazona = value;
            }
        }
        public double elnumerolote
        {
            get
            {
                return this.elnumerolote;
            }
            set
            {
                this.elnumerolote = value;
            }
        }
    }
}


