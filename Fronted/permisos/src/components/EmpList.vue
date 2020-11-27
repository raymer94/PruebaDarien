<template>
  <div class="hello">
    <h1>Lista de Empleados</h1>
    <div class="container">
      <div>
        <router-link to="/register">
          <button type="button" class="btn btn-primary addButton">Nuevo Permiso</button>
        </router-link>
      </div>
      <table class="table">
        <thead>
          <tr>
            <th scope="col">Nombres</th>
            <th scope="col">Apellidos</th>
            <th scope="col">Tipo de Permiso</th>
            <th scope="col">Fecha Permiso</th>
            <th scope="col">Acción</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="permit of permits" v-bind:key="permit.id">
            <th scope="row">{{permit.nombreEmpleado}}</th>
            <td>{{permit.apellidoEmpleado}}</td>
            <td>{{permit.tipoPermiso}}</td>
            <td>{{permit.fechaPermiso}}</td>
            <td>
              <button class="btn btn-primary actionButton" v-on:click="editPermit(permit.id)">
                <i class="fas fa-pencil" aria-hidden="true"></i>
                </button> 
              <button class="btn btn-danger" v-on:click="delPermit(permit.id)">X</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import Swal from 'sweetalert2';
import axios from "axios";
  
  async function getPermit(){
    const res = await axios.get("https://localhost:44315/api/Permisos")
    return res.data;
  }
  async function delPermit(Id) {

    Swal.fire({
  title: 'Seguro?',
  text: "Desea eliminar este permiso?",
  icon: 'warning',
  showCancelButton: true,
  confirmButtonColor: '#3085d6',
  cancelButtonColor: '#d33',
  confirmButtonText: 'Si, borrar!'
}).then((result) => {
  if (result.isConfirmed) {
    axios.delete(`https://localhost:44315/api/Permisos/${Id}`).then((result) => {
    console.log("hola desde ", result)
      window.location.reload();
  });
    

     Swal.fire(
          'Eliminado!',
          'Se ha eliminado.',
          'success'
        )
   }
})
    
  }
  export default {
    name: 'EmpList',
    props: {},
    data: function () {
      return {
        permits: []
      }
    },
    methods: {
      delPermit
    },
    async created() {
      this.permits = await getPermit();
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.actionButton{
  margin-right: 0.5rem;
}
.addButton {
  float: right;
  margin-bottom: 1rem;
}
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
