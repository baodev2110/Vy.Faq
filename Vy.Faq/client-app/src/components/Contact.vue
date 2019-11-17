<template>
  <div>
    <h1>Kontakt oss</h1>
    <p>Fyll skjema for å kontakte oss</p>
    <div class="contact">
      <form id="questionForm">
        <div>
          <label>
            Fornavn
            <input type="text" required v-model="contact.firstname" />
          </label>
        </div>
        <div>
          <label>
            Etternavn
            <input type="text" required v-model="contact.surname" />
          </label>
        </div>
        <div>
          <label>
            Epost
            <input type="email" required v-model="contact.email" />
          </label>
        </div>
        <div>
          <label>
            Telefon
            <input type="tel" required v-model="contact.phone" />
          </label>
        </div>
        <div>
          <label>
            Spørmål
            <textarea type="text" required v-model="contact.question" />
          </label>
        </div>
        <div>
          <button type="button" @click="submit()">Send inn</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      contact: {
        firstname: "Hei",
        surname: "dete",
        email: "sdf",
        phone: "sdf",
        question: "dfsf"
      }
    };
  },
  methods: {
    submit() {
      if (document.querySelector("#questionForm").reportValidity()) {
        let comp = this;
        let contact = comp.contact;
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
</style>