<script lang="ts">
	import { Stepper, Step } from '@skeletonlabs/skeleton';
	import BasicDetailsStep from './create-new-material-steps/BasicDetailsStep.svelte';
	import AllergenInformationStep from './create-new-material-steps/AllergenInformationStep.svelte';
	import CurrentStockStep from './create-new-material-steps/CurrentStockStep.svelte';
	import SummaryStep from './create-new-material-steps/SummaryStep.svelte';

	let id: string = 'dsa';
	let name: string = 'asd';
	let materialType: string = 'Food';
	let unitOfMeasure: string = 'Kilogram';
	let isAllergenByNature: boolean = false;
	let isAllergenByCrossContact: boolean = false;
	let allergensByNature: string[] = [];

	$: isStepIncomplete = !id || !name || !materialType || !unitOfMeasure;
</script>

<div class="card p-8 w-modal shadow-xl space-y-4 min-w-[50vw]">
	<Stepper buttonCompleteLabel="Create Material">
		<Step locked={isStepIncomplete}>
			<svelte:fragment slot="header">Create New Material: Basic details</svelte:fragment>
			<BasicDetailsStep bind:id bind:name bind:materialType bind:unitOfMeasure />
		</Step>
		<Step>
			<svelte:fragment slot="header">Create New Material: Allergen information</svelte:fragment>
			<AllergenInformationStep
				bind:isAllergenByNature
				bind:isAllergenByCrossContact
				bind:allergensByNature
			/>
		</Step>
		<Step>
			<svelte:fragment slot="header">Create New Material: Specify current stock</svelte:fragment>
			<CurrentStockStep />
		</Step>
		<Step>
			<svelte:fragment slot="header">Create New Material: Summary</svelte:fragment>
			<SummaryStep />
		</Step>
	</Stepper>
</div>
