<script lang="ts">
	export let isAllergenByNature: boolean;
	export let isAllergenByCrossContact: boolean;
	export let allergensByNature: string[];

	import { SlideToggle } from '@skeletonlabs/skeleton';

	$: {
		if (!isAllergenByNature) {
			allergensByNature = [];
		}
	}
</script>

<div class="flex items-start justify-between space-x-4">
	<div class="w-1/2">
		<SlideToggle name="Allergen By Nature" bind:checked={isAllergenByNature} size="sm"
			>Allergen by Nature</SlideToggle
		>
		<p class="text-xs opacity-75">
			Materials that inherently contain allergenic substances (eg. peanuts).
		</p>
		<label class="label mt-4">
			<span>Type of Allergen by Nature</span>
			<select
				disabled={!isAllergenByNature}
				class="select"
				multiple
				bind:value={allergensByNature}
				on:change={(e) => console.log(e.currentTarget.value)}
			>
				<option value="Peanuts">Peanuts</option>
				<option value="TreeNuts">Tree Nuts</option>
				<option value="Milk">Milk</option>
				<option value="Eggs">Eggs</option>
				<option value="Soy">Soy</option>
				<option value="Wheat">Wheat</option>
				<option value="Fish">Fish</option>
				<option value="Shellfish">Shellfish</option>
				<option value="Sesame">Sesame</option>
				<option value="Mustard">Mustard</option>
			</select>
		</label>
	</div>

	<div class="w-1/2">
		<SlideToggle name="Allergen By Cross Contact" bind:checked={isAllergenByCrossContact} size="sm"
			>Allergen by Cross Contamination</SlideToggle
		>
		<p class="text-xs opacity-75">
			When allergenic substances from one material are transferred to another material, which
			wouldn't typically contain those allergens.
		</p>
	</div>
</div>
