import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormGroup', defineAsyncComponent(() => import('@/views/forms/FormGroup/QFormGroup.vue')))
		app.component('QFormMember', defineAsyncComponent(() => import('@/views/forms/FormMember/QFormMember.vue')))
		app.component('QFormMemberPsw', defineAsyncComponent(() => import('@/views/forms/FormMemberPsw/QFormMemberPsw.vue')))
	}
}
