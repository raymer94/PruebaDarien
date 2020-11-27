<template>
  <div class="regiForm">
    <div class="container">
      <h1 v-if="permitId">Actualizacion de Permisos</h1>
      <h1 v-else>Registro de Permisos</h1>
      <div class="row">
        <div class="col-md-6">
          <form>
            <div class="form-group">
              <label for="name">Nombres</label>
              <input type="text" class="form-control" id="name" aria-describedby="nameHelp" v-model="name" required="required">
              <small v-if="!valid && !name" class="form-text error">Campo requerido</small>
            </div>
            <div class="form-group">
              <label for="lastname">Apellidos</label>
              <input type="text" class="form-control" id="lastname" aria-describedby="lastnameHelp" v-model="plastName">
             <small v-if="!valid && !plastName" class="form-text error">Campo requerido</small>
            </div>
            <div class="form-group">
              <label for="permitType">Tipo de Permiso</label>
              <select class="form-control" id="permitType" v-model="permitTyper">
                <option disabled selected="selected">Seleccione</option>
                <option v-for="permitType in permitTypes" v-bind:value="permitType.id" v-bind:key="permitType.id">
                  {{permitType.descripcion}}
                </option>
              </select>
              <small v-if="!valid && !permitTyper" class="form-text error">Campo requerido</small>
            </div>
             <div class="form-group">
              <label for="datePermit">Fecha de solicitud</label>
              <input type="date" class="form-control" id="datePermit" aria-describedby="datePermitHelp" v-model="datePermit">
              <small v-if="!valid && !datePermit" class="form-text error">Campo requerido</small>
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

function addPermit(){
  if(this.name && this.plastName && this.permitTyper && this.datePermit){
      this.valid = true;
  }
  else{
    this.valid = false;
  }

  if(this.valid){
    let payload = {
    nombreEmpleado: this.name,
    apellidoEmpleado: this.plastName,
    tipoPermiso: this.permitTyper,
    fechaPermiso: this.datePermit

  };
  
  if(!this.permitId){
      axios.post("https://localhost:44315/api/permisos", payload).then(() => {
  
      });
  }
  else{
    payload.id = parseInt(this.permitId);
     axios.put("https://localhost:44315/api/permisos/"+ this.permitId, payload).then(() => {
      
      });
  }

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
}

 async function getPermit(component){
    component.permitId = window.location.pathname.split("/")[2];

    const res = await axios.get("https://localhost:44315/api/Permisos/"+ component.permitId)
    component.name = res.data.nombreEmpleado;
    component.plastName = res.data.apellidoEmpleado;
    component.permitTyper = res.data.tipoPermiso;
    component.datePermit = res.data.fechaPermiso.split("T").shift();
    return res.data;
  }

  async function getPermitTypes(){
    const res = await axios.get("https://localhost:44315/api/TypePermisos")
    return res.data;
  }

export default {
  name: 'EmpRegister',
  props: {},
  data: function() {
    return {
      permitId: null,
      permitTypes: [],
      name: '',
      plastName: '',
      permitTyper: '',
      datePermit: '',
      valid: true
    }
  },
  methods: {
    addPermit,
    getPermit
  },
   async created() {
      this.permitTypes = await getPermitTypes();
      getPermit(this);
    }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .regiForm {
    text-align: justify;
  }
  .error{
    color:red;
  }
</style>