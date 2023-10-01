<script lang="ts">
	export let form;
</script>

<div>Summary</div>
<input class="input" type="text" name="code" hidden bind:value={$form.code} />
<input class="input" type="text" name="shortName" hidden bind:value={$form.shortName} />
<input class="input" type="text" name="fullName" hidden bind:value={$form.fullName} />
<input class="input" type="text" name="materialTypeId" hidden bind:value={$form.materialTypeId} />
<input class="input" type="text" name="unitOfMeasureId" hidden bind:value={$form.unitOfMeasureId} />
<input class="input" type="text" name="initialStock" hidden bind:value={$form.initialStock} />
<input
	class="input"
	type="text"
	name="isAllergenByNature"
	hidden
	bind:value={$form.isAllergenByNature}
/>
<input
	class="input"
	type="text"
	name="isAllergenByCrossContact"
	hidden
	bind:value={$form.isAllergenByCrossContact}
/>
<input
	class="input"
	type="text"
	name="allergensByNature"
	hidden
	bind:value={$form.allergensByNature}
/>
