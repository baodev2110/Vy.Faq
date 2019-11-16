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
        <div class="q_container" @click="toggle(index)">
          {{item.question}}
          <span
            class="like_info"
          >Likes: {{item.likes}} | Dislikes: {{item.dislikes}}</span>
        </div>
        <div class="a_container" v-show="activeIndexes[index]">
          {{item.answer}}
          <div class="like_buttons">
            <button type="button" @click="like(item.id)">Like</button>
            <button type="button" @click="dislike(item.id)">Dislike</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>  

<script>
import axios from "axios";

export default {
  data() {
    return {
      faqModels: [],
      activeIndexes: []
    };
  },
  mounted() {
    axios.get("/api/Faqs/").then(res => {
      this.faqModels = res.data;
    });
  },
  methods: {
    toggle(index) {
      this.$set(this.activeIndexes, index, !this.activeIndexes[index]);
    },
    like(id) {
      let comp = this;
      axios.post("/api/Faqs/IncreaseLike/?id="+id).then(response => {
        var t = comp.activeIndexes.find(x => x.id === response.data.id);
        window.console.log(t);
      }).catch(res => {
                window.console.log(res);

      });
    },
    dislike(id) {
      let comp = this;

      axios.post("/api/Faqs/IncreaseDislike/?id="+id).then(response => {
        var testing = comp.activeIndexes.find(x => x.id === response.data.id);
        window.console.log(testing);
      });
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
  cursor: pointer;
}
.a_container {
  font-size: 16px;
  padding-top: 20px;
  padding-bottom: 20px;
}
.faqs, .like_buttons {
  padding-top: 40px;
}
.like_info {
  float: right;
}
</style>