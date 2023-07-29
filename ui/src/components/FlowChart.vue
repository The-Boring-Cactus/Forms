<script setup>
import { v4 as uuidv4 } from 'uuid';
import { Panel,MarkerType,Position, VueFlow, isNode, useVueFlow } from '@vue-flow/core'
import { Background } from '@vue-flow/background'
import { Controls } from '@vue-flow/controls'
import { MiniMap } from '@vue-flow/minimap'
import { ref } from 'vue'
const { nodes, addNodes, addEdges, onConnect, dimensions , onEdgeClick} = useVueFlow()
let dark = ref(false);
const dispConnection = ref(false);
const selectedType = ref();
const currentNode = ref();
const nodeTypes = ref([
    { name: 'Accept', code: 'Yes' },
    { name: 'Reject', code: 'No' }
]);
onConnect((params) => { 
    currentNode.value = params;
    selectedType.value = null;
    dispConnection.value = true
    
  }
)



onEdgeClick((params) => {
  //params.edge.label ='Clcik'
  console.log(params.edge)
})
const elements = ref([

]);

function add(){
  const id = uuidv4()

  const newNode = {
    id: `random_node-${id}`,
    label: `Node ${id}`,
    sourcePosition: Position.Right,
    targetPosition: Position.Left,
    position: { x: dimensions.value.width / 2, y: dimensions.value.height / 2 },
  }

  addNodes([newNode])
}
function createNew(){
  elements.value = []
}
function save(){
  console.log(nodes);
}
const items = ref([
    {
      label: 'New Process',
      icon: 'pi pi-fw pi-plus-circle',
      command: createNew,
    },
    {
      label: 'Add Step',
      icon: 'pi pi-fw pi-plus',
      command: add,
    },
    {
      label: 'Save',
      icon: 'pi pi-fw pi-external-link',
      command: save,
    }
]);

function isAccepted()
{

  if(selectedType.value.code==='Yes')
  {
    currentNode.value.label ='Accept'
    currentNode.value.style={ stroke: 'green' }
    currentNode.value.labelBgStyle= {fill :'green' }
  }else{
    currentNode.value.label ='Reject'
    currentNode.value.style={ stroke: 'red' }
    currentNode.value.labelBgStyle= {fill :'red' }
  }
  
  dispConnection.value = false 
  addEdges([currentNode.value])
}

</script>

<template>
  <div class="card relative z-2">
    <Menubar :model="items" />
  <VueFlow v-model="elements"
    class="basicflow"
    :default-edge-options="{ type: 'smoothstep' }"
    :default-viewport="{ zoom: 1.5 }"
    :min-zoom="0.2"
    :max-zoom="5"
    fit-view-on-init>
    <Background :pattern-color="dark ? '#FFFFFB' : '#aaa'" gap="8" />
    <MiniMap />
    <Controls />
  </VueFlow>
  <Dialog v-model:visible="dispConnection" modal :closeOnEscape="false" :closable="false" header="Result" :style="{ width: '50vw' }">
      <p>
          Select the result type.
      </p>
      <Dropdown v-model="selectedType" editable :options="nodeTypes" optionLabel="name" placeholder="Type" class="w-full md:w-14rem" />
      <template #footer>
          <Button label="Ok" icon="pi pi-check" @click="isAccepted" autofocus />
      </template>
  </Dialog>
</div>
</template>

<style>
@import "@vue-flow/core/dist/style.css";
@import "@vue-flow/core/dist/theme-default.css";
@import "@vue-flow/minimap/dist/style.css";
@import "@vue-flow/controls/dist/style.css";
.vue-flow {
    position: relative;
    width: 100%;
    height: 75vh;
    overflow: hidden;
    z-index: 0;
    border-color:gray ;
    border-width: 1px;
}
.vue-flow__minimap {
  transform: scale(75%);
  transform-origin: bottom right;
}

.basicflow.dark{background:#57534e;color:#fffffb}.basicflow.dark 
.vue-flow__node{background:#292524;color:#fffffb}.basicflow.dark 
.vue-flow__controls 
.vue-flow__controls-button{background:#292524;fill:#fffffb;border-color:#fffffb}.basicflow.dark 
.vue-flow__edge-textbg{fill:#292524}.basicflow.dark .vue-flow__edge-text{fill:#fffffb}.basicflow 
.controls{display:flex;flex-wrap:wrap;justify-content:center;gap:8px}.basicflow 
.controls button{padding:4px;border-radius:5px;font-weight:600;-webkit-box-shadow:0px 5px 10px 0px rgba(0,0,0,.3);box-shadow:0 5px 10px #0000004d;cursor:pointer;display:flex;justify-content:center;align-items:center}.basicflow 
.controls button:hover{transform:scale(102%);transition:.25s all ease}
.vue-flow__node-input{border:1px solid #f50505;padding:10px;border-radius:10px;background:#f50505;display:flex;flex-direction:column;justify-content:space-between;align-items:center;gap:10px;max-width:250px; color: #05011f;font-weight: bold;}
.vue-flow__node-output{border:1px solid #0bf703;padding:10px;border-radius:10px;background:#0bf703;display:flex;flex-direction:column;justify-content:space-between;align-items:center;gap:10px;max-width:250px; color: #05011f;font-weight: bold;}
</style>