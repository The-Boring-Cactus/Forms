<script setup>
import { customAlphabet } from 'nanoid'
import draggable from "vuedraggable";
import { ref, computed  } from "vue";
import { useToast } from "primevue/usetoast";
import FormMenu from './forms/FormMenu.vue';
import FormView from './FormView.vue'

const visible = ref(false);
const toast = useToast();
let id = 0;
const formitems = ref([

    {
        label: 'Text input',
        icon: 'pi pi-fw pi-pencil',
        command: add,
    },
    {
        label: 'Auto complete',
        icon: 'pi pi-fw pi-pencil',
        command: add,
    },
    {
        label: 'Phone',
        icon: 'pi pi-fw pi-phone',
        command: add,
    },
    {
        label: 'Integer input',
        icon: 'pi pi-fw pi-plus',
        command: add,
    },
    {
        label: 'Number input',
        icon: 'pi pi-fw pi-plus',
        command: add,
    },
    {
        label: 'Cost input',
        icon: 'pi pi-fw pi-dollar',
        command: add,
    },
    {
        label: 'File upload',
        icon: 'pi pi-fw pi-file',
        command: add,
    },
    {
        label: 'Date',
        icon: 'pi pi-fw pi-calendar',
        command: add,
    },
    {
        label: 'Date range',
        icon: 'pi pi-fw pi-calendar-plus',
        command: add,
    },
    {
        label: 'Radio button',
        icon: 'pi pi-fw pi-circle',
        command: add,
    },
    {
        label: 'Check box',
        icon: 'pi pi-fw pi-check',
        command: add,
    },
    {
        label: 'Editor',
        icon: 'pi pi-fw pi-file-edit',
        command: add,
    },
    {
        label: 'Rating',
        icon: 'pi pi-fw pi-star',
        command: add,
    }
]);
const formstaticitems = ref([

    {
        label: 'H1 Header',
        icon: 'pi pi-fw pi-code',
        command: add,
    },
    {
        label: 'H2 Header',
        icon: 'pi pi-fw pi-code',
        command: add,
    },
    {
        label: 'H3 Header',
        icon: 'pi pi-fw pi-code',
        command: add,
    },
    {
        label: 'H4 Header',
        icon: 'pi pi-fw pi-code',
        command: add,
    },
    {
        label: 'Paragraph',
        icon: 'pi pi-fw pi-wrench',
        command: add,
    },
    {
        label: 'Divider',
        icon: 'pi pi-fw pi-minus',
        command: add,
    }
]);




let list = ref(
    {
        elements: [],
        formvalues: {
            name: 'New Form',
            isGlobal: false
        }        
    })


var previewForm = ref({
    elements: [],
    formvalues: {
        name: 'Test Form',
        isGlobal: false
    }
})

let dragging = ref(false);

let editpanel = ref(false);

function hidepanel(e) {
    editpanel.value = false
};

function customBase64Uploader (event) {
    let file = event.files[0];
    let reader = new FileReader();
    reader.onload = function(){
        var dataURL = reader.result;

    };
    reader.readAsDataURL(file);

};

function add(e) {
    editpanel.value = false;
    id++;
    var i =  customAlphabet('0123456789abcdefghikl',10)();
    console.log(i)
    var item = {};
    if(e.item.label ==='Auto complete'){
        item ={ type: 'AutoComplete', idd:i , name: 'Auto Complete',displaytext: 'Label value' , id, value: '', options: [], optionstmp:[] };
    }
    else if(e.item.label ==='Date range'){
        item ={ type: 'Calendar', idd:i , name: 'Date Range',displaytext: 'Label value' , id, value: '', options: [] };
    }
    else if(e.item.label ==='Date'){
        item ={ type: 'Calendar', idd:i , name: 'Date', displaytext: 'Label value' , id, value: '', options: [] };
    }
    else if(e.item.label ==='Text input'){
        item ={ type: 'InputText', idd:i , name: 'Input Text',displaytext: 'Label value' , id, value: '', options: [] };
    }
    else if(e.item.label ==='Radio button'){
        item ={ type: 'RadioButton', idd:i , name: 'Radio Button',displaytext: 'Label value' , id, value: '', options: ['Option 1'] };
    }
    else if(e.item.label ==='Check box'){
        item ={ type: 'Checkbox', idd:i , name: 'Check Box',displaytext: 'Label value' , id, value: '', options: ['Option 1'] };
    }
    else if(e.item.label ==='Editor'){
        item ={ type: 'Editor', idd:i , name: 'Editor',displaytext: 'Label value' , id, value: '', options: [] };
    }
    else if(e.item.label ==='Integer input'){
        item ={ type: 'Integeronly', idd:i , name: 'Integer Only',displaytext: 'Label value' , id, value: 0, options: [] };
    }
    else if(e.item.label ==='Number input'){
        item ={ type: 'InputNumber', idd:i , name: 'Number',displaytext: 'Label value' , id, value: 0, options: [] };
    }
    else if(e.item.label ==='Cost input'){
        item ={ type: 'InputCost', idd:i , name: 'Cost',displaytext: 'Label value' , id, value: 0, options: [] };
    }
    else if(e.item.label ==='Phone'){
        item ={ type: 'Phone', idd:i , name: 'Phone',displaytext: 'Label value' , id, value: '', options: [] };
    }
    else if(e.item.label ==='Rating'){
        item ={ type: 'Rating', idd:i , name: 'Rating',displaytext: 'Label value' , id, value: '', options: [] };
    }
    else if(e.item.label ==='File upload'){
        item ={ type: 'FileUpload', idd:i , name: 'File upload',displaytext: 'Label value' , id, value: '', options: [] };
    }
    else if(e.item.label ==='H1 Header'){
        item ={ type: 'H1', idd:i , name: 'H1 Header',displaytext: '' , id, value: 'H1 Header', options: [] };
    }
    else if(e.item.label ==='H2 Header'){
        item ={ type: 'H2', idd:i , name: 'H2 Header',displaytext: '' , id, value: 'H2 Header', options: [] };
    }
    else if(e.item.label ==='H3 Header'){
        item ={ type: 'H3', idd:i , name: 'H3 Header',displaytext: '' , id, value: 'H3 Header', options: [] };
    }
    else if(e.item.label ==='H4 Header'){
        item ={ type: 'H4', idd:i , name: 'H4 Header',displaytext: '' , id, value: 'H4 Header', options: [] };
    }
    else if(e.item.label ==='Paragraph'){
        item ={ type: 'P', idd:i , name: 'Paragraph',displaytext: '' , id, value: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', options: [] };
    }
    else if(e.item.label ==='Divider'){
        item ={ type: 'Divider', idd:i , name: 'Divider',displaytext: '' , id, value: '', options: [] };
    }
    else{
        item = { type: 'none', idd:i , name: 'NONE', id, value: "" };
    }
    list.value.elements.push(item);
}
let currElement = ref(false);
function manageitem(e, element)
{

    editpanel.value = false;
    if(element.type ==='Divider')
        return;
    if (!e)
      e = window.event;

    //IE9 & Other Browsers
    if (e.stopPropagation) {
        e.stopPropagation();
    }
    //IE8 and Lower
    else {
        e.cancelBubble = true;
    }
    editpanel.value = true;
    currElement = element;
    console.log(element)

}
function removeitem(element)
{
    editpanel.value = false;

    var filteredArray = list.value.elements.filter(function(e) { return e !== element });
    list.value.elements = filteredArray;
    toast.add({ severity: 'success', summary: 'Element Removed', detail: element.name, life: 1000 });
}
function save()
{
    editpanel.value = false;
    visible.value = true;
    previewForm.value.elements = []
    list.value.elements.forEach(element => previewForm.value.elements.push(JSON.parse(JSON.stringify(element))));
    console.log(list.value);
    console.log(previewForm.value);
}
const fItems = ref([
    {
        label: 'Cancel',
        icon: 'pi pi-fw pi-times-circle',
//        command: createNew,
    },
    {
        label: 'Save',
        icon: 'pi pi-fw pi-external-link',
//        command: save,
    }
]);
</script>
<template>
    <div class="card relative z-2">
    <Menubar :model="fItems" />
        <Toast />
        <h3>Form Builder</h3>
            <div class="flex card-container overflow-hidden">
                <div style="min-width: 20vw;max-width: 20vw;" class=" border-gray-200 border-1 m-2 px-1 py-3">
                    <p class="text-lg font-bold">Form Elements</p>

                    <TabView>
                        <TabPanel header="Fields">
                            <FormMenu :model="formitems" />
                        </TabPanel>
                        <TabPanel header="Static">
                            <FormMenu :model="formstaticitems" />
                        </TabPanel>

                    </TabView>
                </div>
                <div class="flex-grow-1 flex align-items-start border-0 justify-content-center  border-gray-200   m-2 px-5 py-3 " @click="hidepanel">
                    <draggable
                    :list="list.elements"
                    item-key="id"
                    class="list-group "
                    ghost-class="ghost"
                    handle=".handle"
                    @start="dragging = true"
                    @end="dragging = false"
                    style="min-width: 27vw;"
                >
                    <template #item="{ element }">
                            <Panel class="list-group-item"  toggleable w-auto>
                                <template #header>
                                    <div class="flex align-items-center flex-wrap handle" >
                                    <i class="pi pi-fw pi-arrows-v" />
                                    <span>{{element.name}}</span>
                                    </div>
                                </template>
                                <template #icons>
                                    <button v-tooltip="'Options'" class="p-panel-header-icon p-link mr-2" @click="manageitem($event, element)">
                                        <span class="pi pi-cog"></span>
                                    </button>
                                    <button v-tooltip="'Delete'" class="p-panel-header-icon p-link mr-2" @click="removeitem(element)">
                                        <span class="pi pi-trash"></span>
                                    </button>
                                </template>
                                <p class="m-0">  {{ element.displaytext }}</p>
                                <AutoComplete v-if="element.type==='AutoComplete'" v-model="element.value" dropdown :suggestions="element.options" />
                                <Calendar v-if="element.type==='Calendar'&&element.name==='Date'"  v-model="element.value" />
                                <Calendar v-if="element.type==='Calendar'&&element.name==='Date Range'"  v-model="element.value" selectionMode="range" :manualInput="false" />
                                <InputText  v-if="element.type==='InputText'"  type="text" v-model="element.value" />
                                <div v-if="element.type==='RadioButton'"  class="card flex justify-content-center">
                                    <div class="flex flex-wrap gap-3">
                                        <div class="flex align-items-center" v-for="(item, i) of element.options">
                                            <RadioButton v-model="element.value" :inputId="`${element.idd}${i}`" :name="element.idd" :value="item" />
                                            <label :for="`${element.idd}${i}`" class="ml-2">{{item}}</label>
                                        </div>

                                    </div>
                                </div>
                                <Editor v-if="element.type==='Editor'" v-model="element.value"  />

                                <InputMask v-if="element.type==='Phone'"  v-model="element.value" date="phone" mask="(999) 999-9999" placeholder="(999) 999-9999" />
                                <div v-if="element.type==='Checkbox'"  class="card flex justify-content-center">
                                    <div class="flex flex-wrap gap-3">
                                        <div class="flex align-items-center" v-for="(item, i) of element.options">
                                            <Checkbox v-model="element.value" :inputId="`${element.idd}${i}`" :name="element.idd" :value="item" />
                                            <label :for="`${element.idd}${i}`" class="ml-2">{{item}}</label>
                                        </div>

                                    </div>
                                </div>
                                <InputNumber v-if="element.type==='Integeronly'"  v-model="element.value"  inputId="integeronly" />
                                <InputNumber v-if="element.type==='InputNumber'"  v-model="element.value"  />
                                <InputNumber v-if="element.type==='InputCost'"  v-model="element.value" inputId="currency-us" mode="currency" currency="USD" locale="en-US"  />
                                <Rating v-if="element.type==='Rating'"  v-model="element.value"  :cancel="false" />
                                <div v-if="element.type==='FileUpload'" class="card flex justify-content-center">
                                    <FileUpload mode="basic" :name="element.value" customUpload @uploader="customBase64Uploader" />
                                </div>
                                <p v-if="element.type==='H1'" class="text-4xl font-semibold">{{element.value}}</p>
                                <p v-if="element.type==='H2'" class="text-3xl font-semibold">{{element.value}}</p>
                                <p v-if="element.type==='H3'" class="text-2xl font-semibold">{{element.value}}</p>
                                <p v-if="element.type==='H4'" class="text-xl font-semibold">{{element.value}}</p>
                                <p v-if="element.type==='P'" class="text-base font-normal">{{element.value}}</p>
                                <Divider v-if="element.type==='Divider'" />
                            </Panel>
                    </template>
                </draggable>
                </div>
                <div  style="min-width: 15vw;max-width: 15vw;" class="flex-none flex  justify-content-start border-gray-200 border-1 m-2 px-2 py-3">
                    <div  v-if="editpanel">
                        <p class="text-xl font-bold">Options</p>
                        <Divider />
                        <p class="text-lg font-medium text-primary">{{currElement.name}}</p>
                        <div v-if="currElement.type==='H1'||currElement.type==='H2'||currElement.type==='H3'||currElement.type==='H4'||currElement.type==='P'">
                            <p class="text-sm font-medium text-primary">Text to Display</p>
                            <InputText type="text" v-model="currElement.value" class="max-w-full min-w-max"/>
                        </div>
                        <div v-else>
                            <p class="text-sm font-medium text-primary">Label to display</p>
                            <InputText type="text" v-model="currElement.displaytext" class="max-w-full min-w-max"/>
                        </div>
                        <div v-if="currElement.type==='AutoComplete'||currElement.type==='RadioButton'||currElement.type==='Checkbox'">
                            <p class="text-sm font-medium text-primary">Options</p>
                            <Chips id="chips" v-model="currElement.options" />
                        </div>
                    </div>
                    <div  v-else   >
                        <p class="text-lg font-bold">Form Settings</p>
                        <p class="text-sm font-medium text-primary">Name</p>
                        <InputText type="text" v-model="list.formvalues.name" class="max-w-full min-w-max"/>
                        <Divider/>
                        <label class="text-sm font-medium text-primary m-2 ">Global Form</label>
                        <Checkbox v-model="list.formvalues.isGlobal" :binary="true" />
                        <Divider/>
                        <div class="flex justify-content-center flex-wrap card-container">
                            <Button  icon="pi pi-fw pi-eye" label="Preview" @click="save" />
                        </div>
                    </div>
                </div>
            </div>


    </div>
    <Dialog v-model:visible="visible" modal :header="`Preview: ${list.formvalues.name}`" :style="{ width: '50vw' }">
        <FormView :model="previewForm" />
    </Dialog>
</template>


<style scoped>
.button {
  margin-top: 35px;
}
.handle {
  float: left;
  padding-top: 8px;
  padding-bottom: 8px;
  cursor: grab; 
  min-width: 15vw;
}
.close {
  float: right;
  padding-top: 8px;
  padding-bottom: 8px;
}
input {
  display: inline-block;
  width: 50%;
}
.text {
  margin: 20px;
}
</style>