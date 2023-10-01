<script lang="ts">
	export let code: string;
	export let shortName: string;
	export let fullName: string;
	export let materialTypeId: string;
	export let additionalInformation: string;
</script>

<div class="w-full flex items-center justify-between gap-x-4">
	<div class="w-1/2">
		<label class="label">
			<span>Material Code</span>
			<input
				class={`input ${code ? '' : 'input-error'}`}
				type="text"
				name="code"
				bind:value={code}
				placeholder="The ID of the material"
			/>
		</label>
	</div>
	<div class="w-1/2">
		<label class="label">
			<span>Material Type</span>
			<select class="select" bind:value={materialTypeId}>
				<option value="748ca8d1-9eb3-430b-bea5-1e4ddf585815">Food</option>
				<option value="6b8898cc-1ec3-4d7d-bd1c-e4d3890056ee">Beverage</option>
				<!-- <option value="Finished Product">Finished Product</option>
				<option value="Manufacturer Part">Manufacturer Part</option>
				<option value="Simple Packaging Material">Simple Packaging Material</option>
				<option value="Perishable">Perishable</option> -->
			</select>
		</label>
	</div>
</div>

<div class="w-full flex items-center justify-between gap-x-4">
	<div class="w-1/2">
		<label class="label">
			<span>Short Name</span>
			<input
				class={`input ${shortName ? '' : 'input-error'}`}
				type="text"
				bind:value={shortName}
				placeholder="The short name of the material"
			/>
		</label>
	</div>

	<div class="w-1/2">
		<label class="label">
			<span>Full Name</span>
			<input
				class={`input ${fullName ? '' : 'input-error'}`}
				type="text"
				bind:value={fullName}
				placeholder="The full name of the material"
			/>
		</label>
	</div>
</div>

<label class="label">
	<span>Additional Information</span>
	<textarea
		class="textarea min-h-[2.7rem] max-h-[15rem]"
		rows="5"
		bind:value={additionalInformation}
		placeholder="Optionally enter additional information related to the new material."
	/>
</label>
