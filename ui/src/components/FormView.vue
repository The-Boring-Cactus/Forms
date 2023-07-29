<script setup >
import { ref } from 'vue'
const props = defineProps({
    model: Object,
})

const emit = defineEmits(['saveClick'])
const me = ref(this)
function omItemClick(event,  item) {
  emit('saveClick', {event,  item})
}
function customBase64Uploader (event) {
    let file = event.files[0];
    let reader = new FileReader();
    reader.onload = function(){
      var dataURL = reader.result;
      
      console.log( dataURL);
    };
    reader.readAsDataURL(file);

};
const search = (event) => {
    var input  = ""
    var id1 = Object.prototype.toString.call(event.originalEvent).slice(8, -1)
    if(id1==="InputEvent")
    {
        input = event.originalEvent.target.getAttribute('aria-controls').replace('_list', '')
        
    }else
    {
        var nod = event.originalEvent.srcElement.parentNode.parentNode
        var v = nod.tagName
        if(v==="BUTTON"){
            nod = nod.parentNode
            input = nod.id
        }else{
            if(nod.id  !== '')
            {
                input = nod.id
            }else
            {
                let children = nod.children
                Object.keys(children).forEach(key => {
                    if(children[key].id !== ''){
                        input = children[key].id
                    }
                });
            }
        }
              
    }
    var result = props.model.elements.filter(obj => {
        return obj.idd === input
    })[0]
    setTimeout(() => {
        if (!event.query.trim().length) {
            result.optionstmp = [...result.options];
        } else {
            result.optionstmp = result.options.filter((item) => {
                return item.toLowerCase().startsWith(event.query.toLowerCase());
            });
        }
    }, 250);
}
</script>

<template>
    <div class="card">
        <div class="grid">
        <template v-for="(element, l) of model.elements">
            <div v-if="element.type==='AutoComplete'" class="field col-6">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <AutoComplete v-model="element.value" dropdown :id="element.idd" :suggestions="element.optionstmp" @complete="search" />            
            </div>   
            <div v-if="element.type==='Calendar'&&element.name==='Date'" class="field col-6">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <Calendar  v-model="element.value" />
            </div>   
            <div v-if="element.type==='Calendar'&&element.name==='Date Range'" class="field col-6">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <Calendar  v-model="element.value" selectionMode="range" :manualInput="false" />
            </div>   
            <div v-if="element.type==='InputText'"  class="field col-6">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <InputText  type="text" v-model="element.value" />
            </div>
            <div v-if="element.type==='RadioButton'"  class="field col-12">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                    
                <div class="flex flex-wrap gap-3">
                    <div class="flex align-items-center" v-for="(item, i) of element.options">
                        <RadioButton v-model="element.value" :inputId="`${element.idd}${i}`" :name="element.idd" :value="item" />
                        <label :for="`${element.idd}${i}`" class="ml-2">{{item}}</label>
                    </div>
                    
                </div>
            </div>
            <div v-if="element.type==='Editor'" class="field col-12">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <Editor v-model="element.value"  />
            </div>
            <div v-if="element.type==='Phone'"  class="field col-6">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <InputMask v-model="element.value" date="phone" mask="(999) 999-9999" placeholder="(999) 999-9999" />
            </div>
            <div v-if="element.type==='Checkbox'"  class="field col-12">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <div class="flex flex-wrap gap-3">
                    <div class="flex align-items-center" v-for="(item, i) of element.options">
                        <Checkbox v-model="element.value" :inputId="`${element.idd}${i}`" :name="element.idd" :value="item" />
                        <label :for="`${element.idd}${i}`" class="ml-2">{{item}}</label>
                    </div>
                    
                </div>
            </div>
            <div v-if="element.type==='Integeronly'"  class="field col-6">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <InputNumber v-model="element.value"  inputId="integeronly" />
            </div>
            <div v-if="element.type==='InputNumber'"  class="field col-6">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <InputNumber v-model="element.value"  />
            </div>
            <div v-if="element.type==='InputCost'" class="field col-6">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <InputNumber  v-model="element.value" inputId="currency-us" mode="currency" currency="USD" locale="en-US"  />
            </div>
            <div v-if="element.type==='Rating'"  class="field col-6">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <Rating v-model="element.value"  :cancel="false" />
            </div>
            <div v-if="element.type==='FileUpload'" class="field col-12">
                <p class="text-sm font-medium text-primary" v-if="element.displaytext">{{ element.displaytext  }}</p>
                <FileUpload mode="basic" :name="element.value" customUpload @uploader="customBase64Uploader" />
            </div>
            <p v-if="element.type==='H1'" class="text-4xl font-semibold col-12">{{element.value}}</p>
            <p v-if="element.type==='H2'" class="text-3xl font-semibold col-12">{{element.value}}</p>
            <p v-if="element.type==='H3'" class="text-2xl font-semibold col-12">{{element.value}}</p>
            <p v-if="element.type==='H4'" class="text-xl font-semibold col-12">{{element.value}}</p>
            <p v-if="element.type==='P'" class="text-base font-normal col-12">{{element.value}}</p>
            <Divider v-if="element.type==='Divider'" />
            
        </template>
    </div>
    </div>
  </template>
  
  <style scoped>
  </style>