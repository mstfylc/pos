//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'branch_dto.g.dart';

abstract class BranchDto implements Built<BranchDto, BranchDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @nullable
    @BuiltValueField(wireName: r'address')
    String get address;

    @nullable
    @BuiltValueField(wireName: r'phone')
    String get phone;

    @BuiltValueField(wireName: r'entryTrackingMode')
    int get entryTrackingMode;

    @BuiltValueField(wireName: r'active')
    bool get active;

    BranchDto._();

    static void _initializeBuilder(BranchDtoBuilder b) => b;

    factory BranchDto([void updates(BranchDtoBuilder b)]) = _$BranchDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<BranchDto> get serializer => _$BranchDtoSerializer();
}

class _$BranchDtoSerializer implements StructuredSerializer<BranchDto> {

    @override
    final Iterable<Type> types = const [BranchDto, _$BranchDto];
    @override
    final String wireName = r'BranchDto';

    @override
    Iterable<Object> serialize(Serializers serializers, BranchDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'address')
            ..add(object.address == null ? null : serializers.serialize(object.address,
                specifiedType: const FullType(String)));
        result
            ..add(r'phone')
            ..add(object.phone == null ? null : serializers.serialize(object.phone,
                specifiedType: const FullType(String)));
        result
            ..add(r'entryTrackingMode')
            ..add(serializers.serialize(object.entryTrackingMode,
                specifiedType: const FullType(int)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    BranchDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = BranchDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'address':
                    result.address = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'phone':
                    result.phone = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'entryTrackingMode':
                    result.entryTrackingMode = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'active':
                    result.active = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

