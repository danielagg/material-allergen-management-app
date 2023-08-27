<script lang="ts">
    import { Stepper, Step } from '@skeletonlabs/skeleton';

    let id: string = '';
    let name: string = '';

    $: isStepIncomplete = !id || !name

</script>

<div class="card p-8 w-modal shadow-xl space-y-4 min-w-[50vw]">
    <Stepper>
        <Step locked={isStepIncomplete}>
            <svelte:fragment slot="header">Create New Material: Basic details</svelte:fragment>
            <div class="w-full flex items-center justify-between gap-x-4">
                <div class="w-1/2">
                    <label class="label">
                        <span>ID</span>
                        <input autofocus class="input" type="text" value={id} on:input={(e) => {
                            id = e.currentTarget.value
                        }} placeholder="The ID of the material" />
                    </label>                    
                </div>
                <div class="w-1/2">
                    <label class="label">
                        <span>Name</span>
                        <input class="input" type="text" value={name} on:input={(e) => {
                            name = e.currentTarget.value
                        }} placeholder="The name of the material" />
                    </label>                    
                </div>
            </div>
            <div class="w-full flex items-center justify-between gap-x-4">
                <div class="w-1/2">
                    <label class="label">
                        <span>Material Type</span>
                        <select class="select">
                            <option value="1">Food</option>
                            <option value="2">Beverage</option>
                            <option value="4">Finished Product</option>
                            <option value="5">Manufacturer Part</option>
                            <option value="5">Simple Packaging Material</option>
                            <option value="3">Perishable</option>
                        </select>
                    </label>
                </div>
                <div class="w-1/2 flex space-x-2 mt-8 ml-2">
                    <label class="flex items-center space-x-2">
                        <input class="checkbox" type="checkbox" />
                        <p>Hazardous Material</p>
                    </label>
                </div>
            </div>
            <label class="label">
                <span>Additional Information</span>
                <textarea class="textarea min-h-[2.7rem] max-h-[15rem]" rows="5" placeholder="Optionally enter additional information related to the new material." />   
            </label>  
           
        </Step>
        <Step>
            <svelte:fragment slot="header">(header)</svelte:fragment>
            (content)
        </Step>
    </Stepper>
</div>