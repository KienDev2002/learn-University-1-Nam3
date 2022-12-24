
from django import forms
# from .models import contactForm


# class contact_form (forms.ModelForm):
#     class Meta:
#         model = contactForm
#         fields = ['username','email','body']


class contact_form (forms.Form):
    username = forms.CharField(max_length=25)
    email = forms.EmailField()
    body = forms.CharField(widget=forms.Textarea)
    # password = forms.PasswordInput()






