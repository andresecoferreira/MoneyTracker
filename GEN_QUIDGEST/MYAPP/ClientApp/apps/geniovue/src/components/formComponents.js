import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormCategory', defineAsyncComponent(() => import('@/views/forms/FormCategory/QFormCategory.vue')))
		app.component('QFormCategoryType', defineAsyncComponent(() => import('@/views/forms/FormCategoryType/QFormCategoryType.vue')))
		app.component('QFormExpense', defineAsyncComponent(() => import('@/views/forms/FormExpense/QFormExpense.vue')))
		app.component('QFormGroup', defineAsyncComponent(() => import('@/views/forms/FormGroup/QFormGroup.vue')))
		app.component('QFormGroupPsw', defineAsyncComponent(() => import('@/views/forms/FormGroupPsw/QFormGroupPsw.vue')))
		app.component('QFormIncome', defineAsyncComponent(() => import('@/views/forms/FormIncome/QFormIncome.vue')))
		app.component('QFormInvestment', defineAsyncComponent(() => import('@/views/forms/FormInvestment/QFormInvestment.vue')))
		app.component('QFormMember', defineAsyncComponent(() => import('@/views/forms/FormMember/QFormMember.vue')))
		app.component('QFormSource', defineAsyncComponent(() => import('@/views/forms/FormSource/QFormSource.vue')))
		app.component('QFormWdCategories', defineAsyncComponent(() => import('@/views/forms/FormWdCategories/QFormWdCategories.vue')))
	}
}
