<script lang="ts">
	export let id: string;
	export let name: string;
	export let materialType: string;
	export let unitOfMeasure: string;
</script>

<div class="w-full flex items-center justify-between gap-x-4">
	<div class="w-1/2">
		<label class="label">
			<span>Material ID</span>
			<input
				class={`input ${id ? '' : 'input-error'}`}
				type="text"
				bind:value={id}
				on:input={(e) => {
					id = e.currentTarget.value;
				}}
				placeholder="The ID of the material"
			/>
		</label>
	</div>
	<div class="w-1/2">
		<label class="label">
			<span>Material Name</span>
			<input
				class={`input ${name ? '' : 'input-error'}`}
				type="text"
				bind:value={name}
				on:input={(e) => {
					name = e.currentTarget.value;
				}}
				placeholder="The name of the material"
			/>
		</label>
	</div>
</div>
<div class="w-full flex items-center justify-between gap-x-4">
	<div class="w-1/2">
		<label class="label">
			<span>Material Type</span>
			<select
				class="select"
				bind:value={materialType}
				on:change={(e) => (materialType = e.currentTarget.value)}
			>
				<option value="Food">Food</option>
				<option value="Beverage">Beverage</option>
				<option value="Finished Product">Finished Product</option>
				<option value="Manufacturer Part">Manufacturer Part</option>
				<option value="Simple Packaging Material">Simple Packaging Material</option>
				<option value="Perishable">Perishable</option>
			</select>
		</label>
	</div>
	<div class="w-1/2">
		<label class="label">
			<span>Unit of Measure</span>
			<select
				class="select"
				bind:value={unitOfMeasure}
				on:change={(e) => (unitOfMeasure = e.currentTarget.value)}
			>
				<option value="Gram">Gram</option>
				<option value="Kilogram">Kilogram</option>
				<option value="Milliliter">Milliliter</option>
				<option value="Liter">Liter</option>
				<option value="Piece">Piece</option>
			</select>
		</label>
	</div>
</div>
<label class="label">
	<span>Additional Information</span>
	<textarea
		class="textarea min-h-[2.7rem] max-h-[15rem]"
		rows="5"
		placeholder="Optionally enter additional information related to the new material."
	/>
</label>
