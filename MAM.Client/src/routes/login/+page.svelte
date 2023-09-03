<script lang="ts">
	import '../../app.postcss';
	import { AppShell } from '@skeletonlabs/skeleton';
</script>

<AppShell class="relative">
	<div
		class="absolute top-0 bg-warning-300 w-full text-secondary-900 border-b border-b-secondary-500 py-4 flex items-center justify-center"
	>
		<p>
			This is a demo/preview version of the application. Please use the '<span class="font-bold"
				>Login with a demo-account</span
			>' button to sign-in.
		</p>
	</div>
	<div class="min-h-screen flex items-center justify-center">
		<div class="w-1/3 shadow-xl card rounded-3xl p-12 border-y-[12px]">
			<section class="text-center pt-6">
				<h1 class="text-5xl font-bold">Hello!</h1>
				<p class="pt-3 opacity-75">Please sign in, before accessing the app.</p>
			</section>

			<div class="pt-12 flex flex-col items-center justify-center">
				<section class="w-2/3 space-y-4">
					<label class="label">
						<span>Username</span>
						<input class="input" type="text" value="demo-account" disabled />
					</label>
					<label class="label">
						<span>Password</span>
						<input class="input" type="password" disabled value="password-1234" />
					</label>
					<div class="pt-4 space-y-2">
						<button type="button" class="btn variant-filled w-full" disabled>Login</button>
						<button type="button" class="btn variant-filled w-full"
							>Login with a demo-account</button
						>
					</div>

					<div class="pt-12 text-xs text-center">
						<p>
							Don't have an account, yet? <a
								href="/login"
								class="cursor-not-allowed text-blue-500 hover:underline">Click here,</a
							> to register a new one.
						</p>
					</div>
				</section>
			</div>
		</div>
	</div>
</AppShell>
