<template>
  <div>
    <h1>Kontakt oss</h1>
    <p>Fyll skjema for å kontakte oss</p>
    <div class="contact">
      <form id="questionForm">
        <div>
          <label>
            {{labels.firstname}}
            <input
              type="text"
              required
              :disabled="formIsSent"
              v-model="contact.firstname"
              :placeholder="placeholderPrefix+labels.firstname.toLowerCase()"
            />
          </label>
        </div>
        <div>
          <label>
            {{labels.surname}}
            <input
              type="text"
              required
              :disabled="formIsSent"
              v-model="contact.surname"
              :placeholder="placeholderPrefix+labels.surname.toLowerCase()"
            />
          </label>
        </div>
        <div>
          <label>
            {{labels.email}}
            <input
              type="email"
              required
              :disabled="formIsSent"
              v-model="contact.email"
              :placeholder="placeholderPrefix+labels.email.toLowerCase()"
            />
          </label>
        </div>
        <div>
          <label>
            {{labels.phone}}
            <input
              type="tel"
              required
              :disabled="formIsSent"
              v-model="contact.phone"
              :placeholder="placeholderPrefix+labels.phone.toLowerCase()"
            />
          </label>
        </div>
        <div>
          <label>
            {{labels.question}}
            <textarea type="text" required :disabled="formIsSent" v-model="contact.question" />
          </label>
        </div>
        <div>
          <button v-if="!formIsSent" type="button" @click="submit()">Send inn</button>
          <p class="feedback" v-else>Spørsmålet ditt er sendt inn</p>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      formIsSent: false,
      placeholderPrefix: "Skriv inn ",
      labels: {
        firstname: "Fornavn",
        surname: "Etternavn",
        email: "Email",
        phone: "Telefon",
        question: "Spørsmål"
      },
      contact: {
        firstname: "",
        surname: "",
        email: "",
        phone: "",
        question: ""
      }
    };
  },
  methods: {
    submit() {
      if (document.querySelector("#questionForm").reportValidity()) {
        let comp = this;
        let contact = comp.contact;
        comp.formIsSent = true;
        fetch("/api/QuestionForm/", {
          method: "POST",
          body: JSON.stringify(contact),
          headers: {
            "Content-type": "application/json; charset=UTF-8"
          }
        })
          .then(res => {
            window.console.log(res);
          })
          .catch(res => {
            window.console.log(res);
          });
      }
    }
  }
};
</script>

<style>
.contact {
  padding-top: 40px;
}

.feedback {
  color: gray;
}

form input,
form textarea {
  display: block;
  margin: 10px 0 20px 0;
  padding: 5px;
  border: solid 1px #ccc;
  border-radius: 5px;
}
form textarea {
  width: 500px;
  height: 100px;
}

form button {
  border: none;
  border-radius: 15px;
  background: black;
  color: white;
  font-weight: bold;
  padding: 20px 30px 20px 30px;
}

input:focus,
select:focus,
textarea:focus,
button:focus {
  outline: none;
}
</style>