<template>
  <div class="regiForm">
    <div class="container">
      <h1>Registro de Permisos</h1>
      <div class="row">
        <div class="col-md-6">
          <form>
            <div class="form-group">
              <label for="name">Nombres</label>
              <input type="text" class="form-control" id="name" aria-describedby="nameHelp" v-model="name">
              <small class="form-text"></small>
            </div>
            <div class="form-group">
              <label for="lastname">Apellidos</label>
              <input type="text" class="form-control" id="lastname" aria-describedby="lastnameHelp" v-model="plastName">
              <small class="form-text"></small>
            </div>
            <div class="form-group">
              <label for="permitType">Tipo de Permiso</label>
              <select class="form-control" id="permitType" v-model="permitTyper">
                <option disabled selected="selected">Seleccione</option>
                <option v-for="permitType in permitTypes" v-bind:value="permitType.id" v-bind:key="permitType.id">
                  {{permitType.descripcion}}
                </option>
              </select>
            </div>
             <div class="form-group">
              <label for="datePermit">Fecha de solicitud</label>
              <input type="date" class="form-control" id="datePermit" aria-describedby="datePermitHelp" v-model="datePermit">
              <small class="form-text"></small>
            </div>
            <button type="button" class="btn btn-success" v-on:click="addPermit()">Guardar</button>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Swal from 'sweetalert2';
import axios from "axios";



// function addIdTypeSelect(id){
//   console.log(id);
//     tipeSelected =  0;
// }


function addPermit(){
  let payload = {
    nombreEmpleado: this.name,
    apellidoEmpleado: this.plastName,
    tipoPermiso: this.permitTyper,
    fechaPermiso: this.datePermit

  };
  console.log(payload);
  axios.post("https://localhost:44315/api/permisos", payload).then((result) => {
    console.log(result);
  });
  Swal.fire(
    'Guardado!',
    'El permiso ha sido añadido!',
    'success'
  ).then((result) => {
    if (result.isConfirmed) {
      window.location.href = '/';
    }
  })
}

  async function getPermitTypes(){
    const res = await axios.get("https://localhost:44315/api/TypePermisos")
    console.log(res.data);
    return res.data;
  }

export default {
  name: 'EmpRegister',
  props: {},
  data: function() {
    return {
      permitTypes: [],
      name: '',
      plastName: '',
      permitTyper: '',
      datePermit: ''
    }
  },
  methods: {
    addPermit
  },
   async created() {
      this.permitTypes = await getPermitTypes();
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .regiForm {
    text-align: justify;
  }
</style>