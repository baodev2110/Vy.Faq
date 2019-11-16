<template>
  <div>
    <h1>Billetter og setereservasjon</h1>
    <p>Her finner du informasjon om blant annet hvordan du kjøper våre forskjellige billetter, hvordan du reserverer sete eller sovekupé og hvordan vi samarbeider med lokale operatører.</p>
    <div class="faqs">
      <div
        :class="{'qa_container': true, 'last':index===faqModels.length-1}"
        v-for="(item, index) in faqModels"
        :key="index"
      >
        <div class="q_container" @click="toggle(index)">{{item.question}}</div>
        <div class="a_container" v-show="activeIndexes[index]">{{item.answer}}</div>
      </div>
    </div>
  </div>
</template>  

<script>
export default {
  data() {
    return {
      faqModels: [
        {
          question: "Hvordan funker Vy?",
          answer: "Slik funker det",
          likes: 0,
          dislikes: 0
        },
        {
          question: "Hvordan funker Vy2?",
          answer: "Slik funker det2",
          likes: 0,
          dislikes: 0
        }
      ],
      activeIndexes: []
    };
  },
  methods: {
    toggle(index) {
      this.$set(this.activeIndexes, index, !this.activeIndexes[index]);
    }
  }
};
</script>

<style>
.qa_container {
  border-top: 1px solid black;
  padding: 10px;
}
.qa_container.last {
  border-bottom: 1px solid black;
}
.q_container {
  font-size: 16px;
  font-weight: bold;
}
.a_container {
  font-size: 16px;
  padding-top: 20px;
  padding-bottom: 20px;
}
.faqs{
  padding-top: 40px;
}
</style>