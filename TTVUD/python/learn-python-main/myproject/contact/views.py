from django.shortcuts import render
from django.http import HttpResponse
from .forms import contact_form
from .models import contactForm
from django.views import View

# Create your views here.
 # dajng class baseview
class contact(View):
    def get(self, request):
        cf = contact_form
        return render(request,'contact/contact.html',{'cf':cf})

    # def get_contact(request):
    #     if request.method == 'POST':
    #         cf = contact_form (request.POST)
    #         if cf.is_valid():
    #             cf.save()
    #             return HttpResponse('save success')
    #     else:
    #         return HttpResponse('No Post')


    def post(self, request):
        if request.method == "POST":
            cf = contact_form(request.POST)
            if cf.is_valid():
                saveCF = contactForm(username = cf.cleaned_data['username'] , 
                email = cf.cleaned_data['email'] , body = cf.cleaned_data['body'] , 
                # password = cf.cleaned_data['password']
                )
                saveCF.save()
                return HttpResponse('save success')
        else:
            return HttpResponse('not POST')