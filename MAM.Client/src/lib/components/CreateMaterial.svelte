<script lang="ts">
	import { Stepper, Step } from '@skeletonlabs/skeleton';
	import BasicDetailsStep from './create-new-material-steps/BasicDetailsStep.svelte';
	import AllergenInformationStep from './create-new-material-steps/AllergenInformationStep.svelte';
	import CurrentStockStep from './create-new-material-steps/CurrentStockStep.svelte';
	import { superForm } from 'sveltekit-superforms/client';
	import SummaryStep from './create-new-material-steps/SummaryStep.svelte';
	import SuperDebug from 'sveltekit-superforms/client/SuperDebug.svelte';

	// todo: form should be coming from the +page.svelte file under the (protected) root
	const { form, enhance } = superForm(
		{
			code: '',
			shortName: '',
			fullName: '',
			materialTypeId: '',
			additionalInformation: '',
			unitOfMeasureId: '',
			initialStock: 0,
			isAllergenByNature: false,
			isAllergenByCrossContact: false,
			allergensByNature: []
		} as any,
		{
			resetForm: false
		}
	);

	$: isBasicStepIncomplete =
		!$form.code || !$form.shortName || !$form.fullName || !$form.materialTypeId;
</script>

<form action="?/createMaterial" method="POST" use:enhance>
	<div class="card p-8 w-modal shadow-xl space-y-4 min-w-[50vw]">
		<Stepper buttonCompleteLabel="Create Material" buttonCompleteType="submit">
			<Step locked={isBasicStepIncomplete}>
				<svelte:fragment slot="header">Create New Material: Basic details</svelte:fragment>
				<BasicDetailsStep
					bind:code={$form.code}
					bind:shortName={$form.shortName}
					bind:fullName={$form.fullName}
					bind:materialTypeId={$form.materialTypeId}
					bind:additionalInformation={$form.additionalInformation}
				/>
			</Step>
			<Step>
				<svelte:fragment slot="header">Create New Material: Allergen information</svelte:fragment>
				<AllergenInformationStep
					bind:isAllergenByNature={$form.isAllergenByNature}
					bind:isAllergenByCrossContact={$form.isAllergenByCrossContact}
					bind:allergensByNature={$form.allergensByNature}
				/>
			</Step>
			<Step>
				<svelte:fragment slot="header">Create New Material: Specify current stock</svelte:fragment>
				<CurrentStockStep
					bind:unitOfMeasureId={$form.unitOfMeasureId}
					bind:initialStock={$form.initialStock}
				/>
			</Step>
			<Step>
				<svelte:fragment slot="header">Create New Material: Summary</svelte:fragment>
				<SummaryStep {form} />
			</Step>
		</Stepper>
		<SuperDebug data={$form} />
	</div>
</form>
